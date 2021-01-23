    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Xuzzle.Code
    {
    public class CompareHelper
    {
        //Should always be sorted in alphabetical order.
        public static Dictionary<char, List<string>> MyDictionary;
        public static List<string> CurrentWordList;
        //The word we are trying to find matches for.
        public static char InitChar;
        public static StringBuilder ThisWord;
        /// <summary>
        /// Init MyDictionary with the list of words passed in.  Make a new
        /// key value pair with each Letter.
        /// </summary>
        /// <param name="listOfWords"></param>
        public static void InitWords(List<string> listOfWords)
        {
            MyDictionary = new Dictionary<char, List<string>>();
            foreach (char currChar in LetterHelper.Alphabet)
            {
                var wordsParsed = listOfWords.Where(currWord => char.ToUpper(currWord[0]) == currChar).ToArray();
                Array.Sort(wordsParsed);
                MyDictionary.Add(currChar, wordsParsed.ToList());
            }
        }
        /// <summary>
        /// Initialize the Compare.  Set the first character.  See if there are any 1 letter words
        /// for that character.
        /// </summary>
        /// <param name="firstChar">The first character in the word string.</param>
        /// <returns>True if a word was found.</returns>
        public static bool InitCompare(char firstChar)
        {
            InitChar = firstChar;
            //Get all words that start with the firstChar.
            CurrentWordList = MyDictionary[InitChar];
            ThisWord = new StringBuilder();
            ThisWord.Append(firstChar);
            if (CurrentWordList[0].Length == 1)
            {
                //Match.
                return true;
            }
            //No matches.
            return false;
        }
        /// <summary>
        /// Append this letter to our ThisWord.  See if there are any matching words.
        /// </summary>
        /// <param name="nextChar">The next character in the word string.</param>
        /// <returns>True if a word was found.</returns>
        public static bool NextCompare(char nextChar)
        {
            ThisWord.Append(nextChar);
            int currentIndex = ThisWord.Length - 1;
            if (CurrentWordList != null && CurrentWordList.Count > 0)
            {
                CurrentWordList = CurrentWordList.Where(word => (word.Length < currentIndex ? false : word[currentIndex] == nextChar)).ToList();
                if (CurrentWordList != null && CurrentWordList.Count > 0)
                {
                    if (CurrentWordList[0].Length == ThisWord.Length)
                    {
                        //Match.
                        return true;
                    }
                }
            }
            //No matches.
            return false;
        }
    }
    }
