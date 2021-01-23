    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(new Program(new[] { "kissing_heart", "bouquet", "grinning" }).RemoveEmoji("Hello:grinning: , ho:w: a::re you?:kissing_heart: Are you fine?:bouquet:"));
                Console.ReadLine();
            }
            private ISet<string> emojiList;
            public Program(IEnumerable<string> emojiList)
            {
                this.emojiList = new HashSet<string>(emojiList);
            }
            public string RemoveEmoji(string input)
            {
                StringBuilder sb = new StringBuilder();
                input.Split(':').Aggregate( true , (prev, curr) =>
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
                    sb.Append(":");
                    sb.Append(curr);
                    return false;
                });
                return sb.ToString();
            }
        }
    }
