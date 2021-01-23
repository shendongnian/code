    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        static class Program
        {
            static void Main(string[] args)
            {
                ISet<string> emojiList = new HashSet<string>(new[] { "kissing_heart", "bouquet", "grinning" });
                Console.WriteLine("Hello:grinning: , ho:w: a::re you?:kissing_heart:kissing_heart: Are you fine?:bouquet:".RemoveEmoji(':', emojiList));
                Console.ReadLine();
            }
            public static string RemoveEmoji(this string input, char delimiter, ISet<string> emojiList)
            {
                StringBuilder sb = new StringBuilder();
                input.Split(delimiter).Aggregate(true, (prev, curr) =>
                {
                    if (prev)
                    {
                        sb.Append(curr);
                        return false;
                    }
                    if (emojiList.Contains(curr))
                    {
                        return true;
                    }
                    sb.Append(delimiter);
                    sb.Append(curr);
                    return false;
                });
                return sb.ToString();
            }
        }
    }
