    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main()
            {
                var inputFilenames = new string[]
                {
                    "mtn_flint501-muxed",
                    "mtn_flint502-muxed",
                    "mtn_flint503-muxed",
                    "mtn_flint504-muxed",
                    "mtn_flint505-muxed",
                    "mtn_flint506-muxed",
                    "mtn_flint507-muxed",
                    "mtn_flint508-muxed",
                    "mtn_flint509-muxed",
                    "mtn_flint510-muxed",
                    "mtn_flint511-muxed",
                    "mtn_flint512-muxed",
                };
                var replacedFilenames = ReplaceFileNames(inputFilenames);
    
                for (int i = 0; i < inputFilenames.Length; i++)
                {
                    Console.WriteLine("{0} >> {1}", inputFilenames[i], replacedFilenames[i]);
                }
                Console.ReadKey();
            }
    
            private const string OurPrefixPattern = "Prefix_";
            private const string OurPostfixPattern = "_Postfix";
    
            /// <summary>
            /// Method which will find the filename's pattern and replace it with our pattern
            /// </summary>
            /// <param name="fileNames"></param>
            /// <returns></returns>
            public static string[] ReplaceFileNames(params string[] fileNames)
            {
                //At first, we will find count of characters, which are same for
                //all filenames as prefix and store it to prefixCount variable and
                //we will find count of characters which are same for all filenames
                //as postfix and store it to postfixCount variable
                var prefixCount = int.MaxValue;
                var postfixCount = int.MaxValue;
                //We will use first filename as the reference one (we will be comparing)
                //all filenames with this one
                var referenceFilename = fileNames[0];
                var reversedReferenceFilename = referenceFilename.ReverseString();
                //Lets find the prefixCount and postfixCount
                foreach (var filename in fileNames)
                {
                    if (filename == referenceFilename)
                    {
                        continue;
                    }
                    //Check for prefix count
                    var firstDifferenceIndex = referenceFilename.GetFirstDifferentIndexWith(filename);
                    if (firstDifferenceIndex < prefixCount)
                    {
                        prefixCount = firstDifferenceIndex;
                    }
                    //For postfix count we will do the same, but with reversed strings
                    firstDifferenceIndex = reversedReferenceFilename.GetFirstDifferentIndexWith(filename.ReverseString());
                    if (firstDifferenceIndex < postfixCount)
                    {
                        postfixCount = firstDifferenceIndex;
                    }
                }
                //So now replace given filnames with our prefix and post fix.
                //Our regex determines only how many characters should be replaced
                var prefixRegexToReplace = string.Format("^.{{{0}}}", prefixCount);
                var postfixRegexToReplace = string.Format(".{{{0}}}$", postfixCount);
                var result = new string[fileNames.Length];
                for (int i = 0; i < fileNames.Length; i++)
                {
                    //Replace the prefix
                    result[i] = Regex.Replace(fileNames[i], prefixRegexToReplace, OurPrefixPattern);
                    //Replace the postfix
                    result[i] = Regex.Replace(result[i], postfixRegexToReplace, OurPostfixPattern);
                }
                return result;
            }
    
            /// <summary>
            /// Gets the first index in which the strings has different character
            /// </summary>
            /// <param name="value"></param>
            /// <param name="stringToCompare"></param>
            /// <returns></returns>
            private static int GetFirstDifferentIndexWith(this string value, string stringToCompare)
            {
                return value.Zip(stringToCompare, (c1, c2) => c1 == c2).TakeWhile(b => b).Count();
            }
    
            /// <summary>
            /// Revers given string
            /// </summary>
            /// <param name="value">String which should be reversed</param>
            /// <returns>Reversed string</returns>
            private static string ReverseString(this string value)
            {
                char[] charArray = value.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }
    }
