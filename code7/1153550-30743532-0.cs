	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reactive.Linq;
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
                input.Split(':').ToObservable().Scan(new { curr = "", pmatch = true }, (prev, curr) =>
                {
                    if (prev.pmatch)
                    {
                        return new { curr = curr, pmatch = false };
                    }
                    if (emojiList.Contains(curr))
                    {
                        return new { curr = "", pmatch = true };
                    }
                    return new { curr = ":" + curr, pmatch = false };
                }).Select(el => el.curr)
                .Subscribe(el => sb.Append(el));
                return sb.ToString();
            }
        }
    }
