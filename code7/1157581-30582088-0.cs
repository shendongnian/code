     public class CompareHelper
     {
        //Should always be sorted in alphabetical order.
        public static Dictionary<char, List<string>> MyDictionary;
        public static List<string> CurrentWordList;
        public static List<string> MatchedWordList;
        //The word we are trying to find matches for.
        public static char InitChar;
        public static StringBuilder ThisWord;
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
            if (FindRemainingWords(nextChar, currentIndex))
            {
                if (CurrentWordList[0].Length == currentIndex)
                {
                    //Match.
                    return true;
                }
            }
            //No matches.
            return false;
        }
        
        /// <summary>
        /// Trim down our CurrentWordList until it only contains words
        /// that at currIndex start with the currChar.
        /// </summary>
        /// <param name="currChar">The next letter in our ThisWord.</param>
        /// <param name="currIndex">The index of the letter.</param>
        /// <returns>True if there are words remaining in CurrentWordList.</returns>
        private static bool FindRemainingWords(char currChar, int currIndex)
        {
            //Null check.
            if (CurrentWordList == null || CurrentWordList.Count < 1)
            {
                return false;
            }
            bool doneSearching = false;
            while(!doneSearching)
            {
                int middleIndex = CurrentWordList.Count / 2;
                //TODO: test for CurrentWordList.count 2 or 1 ...
                //TODO: test for wordToCheck.length < curr index
                char middleLetter = CurrentWordList[middleIndex][currIndex];
                
                LetterPositionEnum returnEnum = GetLetterPosition(currChar, middleLetter);
                switch(returnEnum)
                {
                    case LetterPositionEnum.Before:
                        CurrentWordList = CurrentWordList.GetRange(middleIndex, (CurrentWordList.Count - middleIndex));
                        break;
                    case LetterPositionEnum.PREV:
                        CurrentWordList = CurrentWordList.GetRange(middleIndex, (CurrentWordList.Count - middleIndex));
                        break;
                    case LetterPositionEnum.MATCH:
                        CurrentWordList = CurrentWordList.GetRange(middleIndex, (CurrentWordList.Count - middleIndex));
                        break;
                    case LetterPositionEnum.NEXT:
                        CurrentWordList = CurrentWordList.GetRange(0, middleIndex);
                        break;
                    case LetterPositionEnum.After:
                        CurrentWordList = CurrentWordList.GetRange(0, middleIndex);
                        break;
                    default:
                        break;
                }
            }
            TrimWords(currChar, currIndex);
            //Null check.
            if (CurrentWordList == null || CurrentWordList.Count < 1)
            {
                return false;
            }
            //There are still words left in CurrentWordList.
            return true;
        }
        //Trim all words in CurrentWordList 
        //that are LetterPositionEnum.PREV and LetterPositionEnum.NEXT
        private static void TrimWords(char currChar, int currIndex)
        {
            int startIndex = 0;
            int endIndex = CurrentWordList.Count;
            bool startIndexFound = false;
            //Loop through all of the words.
            for ( int i = startIndex; i < endIndex; i++)
            {
                //If we havent found the start index then the first match of currChar
                //will be the start index.
                 if( !startIndexFound &&  currChar == CurrentWordList[i][currIndex] )
                {
                    startIndex = i;
                    startIndexFound = true;
                }
                 //If we have found the start index then the next letter that isnt 
                 //currChar will be the end index.
                 if( startIndexFound && currChar != CurrentWordList[i][currIndex])
                {
                    endIndex = i;
                    break;
                }
            }
            //Trim the words that dont start with currChar.
            CurrentWordList = CurrentWordList.GetRange(startIndex, endIndex);
        }
        //In order to find all words that begin with a given character, we should search
        //for the last word that begins with the previous character (PREV) and the 
        //first word that begins with the next character (NEXT).
        //Anything else Before or After that is trash and we will throw out.
        public enum LetterPositionEnum
        {
            Before,
            PREV,
            MATCH,
            NEXT,
            After
        };
        //We want to ignore all letters that come before this one.
        public static LetterPositionEnum GetLetterPosition(char currChar, char compareLetter)
        {
            switch (currChar)
            {
                case 'A':
                    switch (compareLetter)
                    {
                        case 'A': return LetterPositionEnum.MATCH;
                        case 'B': return LetterPositionEnum.NEXT;
                        case 'C': return LetterPositionEnum.After;
                        case 'D': return LetterPositionEnum.After;
                        case 'E': return LetterPositionEnum.After;
                        case 'F': return LetterPositionEnum.After;
                        case 'G': return LetterPositionEnum.After;
                        case 'H': return LetterPositionEnum.After;
                        case 'I': return LetterPositionEnum.After;
                        case 'J': return LetterPositionEnum.After;
                        case 'K': return LetterPositionEnum.After;
                        case 'L': return LetterPositionEnum.After;
                        case 'M': return LetterPositionEnum.After;
                        case 'N': return LetterPositionEnum.After;
                        case 'O': return LetterPositionEnum.After;
                        case 'P': return LetterPositionEnum.After;
                        case 'Q': return LetterPositionEnum.After;
                        case 'R': return LetterPositionEnum.After;
                        case 'S': return LetterPositionEnum.After;
                        case 'T': return LetterPositionEnum.After;
                        case 'U': return LetterPositionEnum.After;
                        case 'V': return LetterPositionEnum.After;
                        case 'W': return LetterPositionEnum.After;
                        case 'X': return LetterPositionEnum.After;
                        case 'Y': return LetterPositionEnum.After;
                        case 'Z': return LetterPositionEnum.After;
                        default: return LetterPositionEnum.After;
                    }
                case 'B':
                    switch (compareLetter)
                    {
                        case 'A': return LetterPositionEnum.PREV;
                        case 'B': return LetterPositionEnum.MATCH;
                        case 'C': return LetterPositionEnum.NEXT;
                        case 'D': return LetterPositionEnum.After;
                        case 'E': return LetterPositionEnum.After;
                        case 'F': return LetterPositionEnum.After;
                        case 'G': return LetterPositionEnum.After;
                        case 'H': return LetterPositionEnum.After;
                        case 'I': return LetterPositionEnum.After;
                        case 'J': return LetterPositionEnum.After;
                        case 'K': return LetterPositionEnum.After;
                        case 'L': return LetterPositionEnum.After;
                        case 'M': return LetterPositionEnum.After;
                        case 'N': return LetterPositionEnum.After;
                        case 'O': return LetterPositionEnum.After;
                        case 'P': return LetterPositionEnum.After;
                        case 'Q': return LetterPositionEnum.After;
                        case 'R': return LetterPositionEnum.After;
                        case 'S': return LetterPositionEnum.After;
                        case 'T': return LetterPositionEnum.After;
                        case 'U': return LetterPositionEnum.After;
                        case 'V': return LetterPositionEnum.After;
                        case 'W': return LetterPositionEnum.After;
                        case 'X': return LetterPositionEnum.After;
                        case 'Y': return LetterPositionEnum.After;
                        case 'Z': return LetterPositionEnum.After;
                        default: return LetterPositionEnum.After;
                    }
                case 'C':
                    switch (compareLetter)
                    {
                        case 'A': return LetterPositionEnum.Before;
                        case 'B': return LetterPositionEnum.PREV;
                        case 'C': return LetterPositionEnum.MATCH;
                        case 'D': return LetterPositionEnum.NEXT;
                        case 'E': return LetterPositionEnum.After;
                        case 'F': return LetterPositionEnum.After;
                        case 'G': return LetterPositionEnum.After;
                        case 'H': return LetterPositionEnum.After;
                        case 'I': return LetterPositionEnum.After;
                        case 'J': return LetterPositionEnum.After;
                        case 'K': return LetterPositionEnum.After;
                        case 'L': return LetterPositionEnum.After;
                        case 'M': return LetterPositionEnum.After;
                        case 'N': return LetterPositionEnum.After;
                        case 'O': return LetterPositionEnum.After;
                        case 'P': return LetterPositionEnum.After;
                        case 'Q': return LetterPositionEnum.After;
                        case 'R': return LetterPositionEnum.After;
                        case 'S': return LetterPositionEnum.After;
                        case 'T': return LetterPositionEnum.After;
                        case 'U': return LetterPositionEnum.After;
                        case 'V': return LetterPositionEnum.After;
                        case 'W': return LetterPositionEnum.After;
                        case 'X': return LetterPositionEnum.After;
                        case 'Y': return LetterPositionEnum.After;
                        case 'Z': return LetterPositionEnum.After;
                        default: return LetterPositionEnum.After;
                    }
    //etc.  Stack Overflow limits characters to 30,000 contact me for full switch case.
       default: return LetterPositionEnum.After;
            }
        }
    }
