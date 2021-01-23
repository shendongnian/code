    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var words = new Dictionary<int, string>();
                int i = 0;
                string teststring;
                while (true)
                {
                    i++;
                    teststring = i.ToString();
                    try
                    {
                        words.Add(teststring.GetHashCode(), teststring);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                var collisionHash = teststring.GetHashCode();
                Console.WriteLine("\"{0}\" and \"{1}\" have the same hash code {2}", words[collisionHash], teststring, collisionHash);
                Console.ReadLine();
            }
        }
    }
