    using System;
    namespace PigLatin
    {
      public class Translate
      {
        public static string Transfer(string input)
        {
            string firstChar = "";
            string lastChars = "";
            int x;
            string vowel = "AEIOUaeiou";
            string[] pieces = input.Split(null);
            try
            {
                foreach (string piece in pieces)
                {
                    lastChars = piece.Substring(1);
                    firstChar = piece.Substring(0, 1);
                    x = vowel.IndexOf(firstChar);
                    if (x == -1)
                    {
                        var pigLatin = lastChars + firstChar + "ay";
                        return pigLatin;
                    }
                    else
                    {
                        var pigLatin = firstChar + lastChars + "way";
                        return pigLatin;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return 1; //or add any valid return value. This is your missing statement
        }
        static void Main(string[] args)
        {
            Console.Write("Enter word to translate: ");
            var toTranslate = Console.ReadLine();
            Console.WriteLine(Transfer(toTranslate));
        }
      }
    }
