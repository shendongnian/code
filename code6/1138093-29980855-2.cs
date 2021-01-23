            public static string[] WORDS = new[]
        {
            "ANY","LIST","OF","WORDS"
        };
        private static ObsceneNode _root;
        static SmutBlocker()
        {
            var abbreviatedList = new List<string>();
            _root = new ObsceneNode(new ObsceneValue(default(char), null));
            var iter = _root;
            foreach (var word in WORDS)
            {
                for(var i = 0; i < word.Length; i++)
                {
                    if (iter.Value.IsObscene)
                        break;
                    var isObscene = (word.Length - 1) == i;
                    iter = iter.SafeAddChild(new ObsceneValue(word[i], isObscene ? word : null));
                    if (isObscene)
                        abbreviatedList.Add(word.ToUpper());
                }
                iter = _root;
            }
            var output = String.Empty;
            for (var i = 0; i < abbreviatedList.Count(); i += 10)
            {
                var segment = abbreviatedList.Skip(i).Take(10);
                output += "\"" + String.Join("\",\"", segment) + "\"," + Environment.NewLine;
            }
        }
        
        //Finally the actual IsObscene check that loops through the tree.
        public static bool IsObscene(string text)
        {
            var iter = _root;
            for (var i = 0; i < text.Length; i++)
            {
                for (var j = i; j < text.Length; j++)
                {
                    var c = text[j];
                    if (iter.HasChild(c))
                    {
                        iter = iter.GetChild(c);
                    }
                    else
                    {
                        break;
                    }
                    if (iter.Value.IsObscene)
                        return true;
                }
                iter = _root;
            }
            return false;
        }
    }
