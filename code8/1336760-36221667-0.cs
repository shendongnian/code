    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    namespace Com.HanelDev.HSpell
    {
        public class HSpellProcess
        {
            private Dictionary<string, string> _dictionary = new Dictionary<string, string>();
            public int MaxSuggestionResponses { get; set; }
            public HSpellProcess()
            {
                MaxSuggestionResponses = 10;
            }
            public void AddToDictionary(string w)
            {
                if (!_dictionary.ContainsKey(w.ToLower()))
                {
                    _dictionary.Add(w.ToLower(), w);
                }
                else
                {
                    // Upper case words are more specific (but may be the first word
                    // in a sentence.) Lower case words are more generic.
                    // If you put an upper-case word in the dictionary, then for
                    // it to be "correct" it must match case. This is not true
                    // for lower-case words.
                    // We want to only replace existing words with their more
                    // generic versions, not the other way around.
                    if (_dictionary[w.ToLower()].CaseSensitive())
                    {
                        _dictionary[w.ToLower()] = w;
                    }
                }
            }
            public void LoadDictionary(byte[] dictionaryFile, bool resetDictionary = false)
            {
                if (resetDictionary)
                {
                    _dictionary = new Dictionary<string, string>();
                }
                using (MemoryStream ms = new MemoryStream(dictionaryFile))
                {
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        string tmp = sr.ReadToEnd();
                        tmp = tmp.Replace("\r\n", "\r").Replace("\n", "\r");
                        string [] fileData = tmp.Split("\r".ToCharArray());
                        foreach (string line in fileData)
                        {
                            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                            {
                                continue;
                            }
                            string word = line;
                            // I added all of this for file imports (not array imports)
                            // to be able to handle words from Hunspell dictionaries.
                            // I don't get the hunspell derivatives, but at least I get
                            // the root word.
                            if (line.Contains("/"))
                            {
                                string[] arr = line.Split("/".ToCharArray());
                                word = arr[0];
                            }
                            AddToDictionary(word);
                        }
                    }
                }
            }
            public void LoadDictionary(Stream dictionaryFileStream, bool resetDictionary = false)
            {
                string s = "";
                using (StreamReader sr = new StreamReader(dictionaryFileStream))
                {
                    s = sr.ReadToEnd();
                }
                byte [] bytes = Encoding.UTF8.GetBytes(s);
                LoadDictionary(bytes, resetDictionary);
            }
            public void LoadDictionary(List<string> words, bool resetDictionary = false)
            {
                if (resetDictionary)
                {
                    _dictionary = new Dictionary<string, string>();
                }
                foreach (string line in words)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    {
                        continue;
                    }
                    AddToDictionary(line);
                }
            }
            public string ExportDictionary()
            {
                StringBuilder sb = new StringBuilder();
                foreach (string k in _dictionary.Keys)
                {
                    sb.AppendLine(_dictionary[k]);
                }
                return sb.ToString();
            }
            public HSpellCorrections Correct(string word)
            {
                HSpellCorrections ret = new HSpellCorrections();
                ret.Word = word;
                if (_dictionary.ContainsKey(word.ToLower()))
                {
                    string testWord = word;
                    string dictWord = _dictionary[word.ToLower()];
                    if (!dictWord.CaseSensitive())
                    {
                        testWord = testWord.ToLower();
                        dictWord = dictWord.ToLower();
                    }
                    if (testWord == dictWord)
                    {
                        ret.SpelledCorrectly = true;
                        return ret;
                    }
                }
                // At this point, we know the word is assumed to be spelled incorrectly. 
                // Go get word candidates.
                ret.SpelledCorrectly = false;
                Dictionary<string, HSpellWord> candidates = new Dictionary<string, HSpellWord>();
                List<string> edits = Edits(word);
                GetCandidates(candidates, edits);
                if (candidates.Count > 0)
                {
                    return BuildCandidates(ret, candidates);
                }
                // If we didn't find any candidates by the main word, look for second-level candidates based on the original edits.
                foreach (string item in edits)
                {
                    List<string> round2Edits = Edits(item);
                    GetCandidates(candidates, round2Edits);
                }
                if (candidates.Count > 0)
                {
                    return BuildCandidates(ret, candidates);
                }
                return ret;
            }
            private void GetCandidates(Dictionary<string, HSpellWord> candidates, List<string> edits)
            {
                foreach (string wordVariation in edits)
                {
                    if (_dictionary.ContainsKey(wordVariation.ToLower()) &&
                        !candidates.ContainsKey(wordVariation.ToLower()))
                    {
                        HSpellWord suggestion = new HSpellWord(_dictionary[wordVariation.ToLower()]);
                        suggestion.RelativeMatch = RelativeMatch.Compute(wordVariation, suggestion.Word);
                        candidates.Add(wordVariation.ToLower(), suggestion);
                    }
                }
            }
            private HSpellCorrections BuildCandidates(HSpellCorrections ret, Dictionary<string, HSpellWord> candidates)
            {
                var suggestions = candidates.OrderByDescending(c => c.Value.RelativeMatch);
                int x = 0;
                ret.Suggestions.Clear();
                foreach (var suggest in suggestions)
                {
                    x++;
                    ret.Suggestions.Add(suggest.Value.Word);
                    // only suggest the first X words.
                    if (x >= MaxSuggestionResponses)
                    {
                        break;
                    }
                }
                return ret;
            }
            private List<string> Edits(string word)
            {
                var splits = new List<Tuple<string, string>>();
                var transposes = new List<string>();
                var deletes = new List<string>();
                var replaces = new List<string>();
                var inserts = new List<string>();
                // Splits
                for (int i = 0; i < word.Length; i++)
                {
                    var tuple = new Tuple<string, string>(word.Substring(0, i), word.Substring(i));
                    splits.Add(tuple);
                }
                // Deletes
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    if (!string.IsNullOrEmpty(b))
                    {
                        deletes.Add(a + b.Substring(1));
                    }
                }
                // Transposes
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    if (b.Length > 1)
                    {
                        transposes.Add(a + b[1] + b[0] + b.Substring(2));
                    }
                }
                // Replaces
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    if (!string.IsNullOrEmpty(b))
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            replaces.Add(a + c + b.Substring(1));
                        }
                    }
                }
                // Inserts
                for (int i = 0; i < splits.Count; i++)
                {
                    string a = splits[i].Item1;
                    string b = splits[i].Item2;
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        inserts.Add(a + c + b);
                    }
                }
                return deletes.Union(transposes).Union(replaces).Union(inserts).ToList();
            }
            public HSpellCorrections CorrectFrom(string txt, int idx)
            {
                if (idx >= txt.Length)
                {
                    return null;
                }
                // Find the next incorrect word.
                string substr = txt.Substring(idx);
                int idx2 = idx;
                List<string> str = substr.Split(StringExtensions.WordDelimiters).ToList();
                foreach (string word in str)
                {
                    string tmpWord = word;
                    if (string.IsNullOrEmpty(word))
                    {
                        idx2++;
                        continue;
                    }
                    // If we have possessive version of things, strip the 's off before testing
                    // the word. THis will solve issues like "My [mother's] favorite ring."
                    if (tmpWord.EndsWith("'s"))
                    {
                        tmpWord = word.Substring(0, tmpWord.Length - 2);
                    }
                    // Skip things like ***, #HashTagsThatMakeNoSense and 1,2345.67
                    if (!tmpWord.IsWord())
                    {
                        idx2 += word.Length + 1;
                        continue;
                    }
                    HSpellCorrections cor = Correct(tmpWord);
                    if (cor.SpelledCorrectly)
                    {
                        idx2 += word.Length + 1;
                    }
                    else
                    {
                        cor.Index = idx2;
                        return cor;
                    }
                }
                return null;
            }
        }
    }
