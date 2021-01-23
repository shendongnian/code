    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            private static string testData = "<sdf<xml><something/></xml><smc<xml><something/><ueo<xml><something /></xml>";
            static void Main(string[] args)
            {
                Func<string, string> stripInvalidXml = input => {
                    Func<int, bool> shouldSkip = index =>
                    {
                        var xI = index + 4; //add 4 to see what's after the current 4 characters
                        if (xI >= (input.Length - 5)) //make sure adding 4 and the length of <xml> doesn't exceed end of input
                            return false;
                        if (input.Substring(xI, 5) == "<xml>") //check if the characters 4 indexes after the current character are <xml>
                            return true; //skip the current index
                        return false; //don't skip
                    };
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < input.Length; ++i)
                    {
                        //loop through each character and see if the characters 4 after are <xml>
                        char c = input[i];
                        if (shouldSkip(i))
                            i += 3; //if should skip, we are already on the first character, so add 3 more to skip to skip 4 characters
                        else
                            sb.Append(c);
                    }
                    return sb.ToString();
                };
                Console.WriteLine(stripInvalidXml(testData));
                Console.ReadKey(true);
            }
    
        }
    }
