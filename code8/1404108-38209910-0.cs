    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace testSerializer
    {
        class Program
        {
            private static string filePath = AppDomain.CurrentDomain.BaseDirectory + "testFile.xml";
            private static string tempFile = AppDomain.CurrentDomain.BaseDirectory + "tempFile.xml";
    
            private static Dictionary<string, string> specialCharacterList = new Dictionary<string, string>()
            {
                {"&","&amp;"}, {"<","&lt;"}, {">","&gt;"}, {"'","&apos;"}, {"\"","&quot;"}
            };
    
            static void Main(string[] args)
            {
                ReplaceSpecialCharacters();
            }
    
            private static void ReplaceSpecialCharacters()
            {
                string[] allLines = File.ReadAllLines(filePath);
    
                using (TextWriter tw = File.CreateText(tempFile))
                {
                    foreach (string strLine in allLines)
                    {
                        string newLineString = "";
                        string originalString = strLine;
    
                        foreach (var item in specialCharacterList)
                        {
                            // Since these characters are all valid characters to be present in the XML,
                            // We need to look specifically within the VALUE of the XML Element.
                            if (item.Key == "\"" || item.Key == "<" || item.Key == ">")
                            {
                                // Find the ending character of the beginning XML tag.
                                int firstIndexOfCloseBracket = originalString.IndexOf('>');
    
                                // Find the beginning character of the ending XML tag.
                                int lastIndexOfOpenBracket = originalString.LastIndexOf('<');
    
                                if (lastIndexOfOpenBracket > firstIndexOfCloseBracket)
                                {
                                    // Determine the length of the string between the XML tags.
                                    int lengthOfStringBetweenBrackets = lastIndexOfOpenBracket - firstIndexOfCloseBracket;
    
                                    // Retrieve the string that is between the element tags.
                                    string valueOfElement = originalString.Substring(firstIndexOfCloseBracket + 1, lengthOfStringBetweenBrackets - 1);
    
                                    newLineString = originalString.Substring(0, firstIndexOfCloseBracket + 1) + valueOfElement.Replace(item.Key, item.Value) + originalString.Substring(lastIndexOfOpenBracket);
                                }
                            }
                            // For the ampersand (&) and apostrophe (') characters, simply replace any found with the escape.
                            else
                            {
                                newLineString = originalString.Replace(item.Key, item.Value);
                            }
    
                            // Set the "original" string to the new version.
                            originalString = newLineString;
                        }
    
                        tw.WriteLine(newLineString);
                    }
                }
            }
        }
    }
