    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class DupeInfo
        {
            public string Text;
            public int Index;
            public int Count;
        }
        static class Program
        {
            static void Main()
            {
                var test = new[]
                {
                    "1",
                    "2", "2",
                    "A",
                    "3", "3", "3",
                    "B",
                    "4", "4", "4", "4",
                    "C",
                };
                foreach (var dupeinfo in FindRepeats(test))
                    Console.WriteLine($"{dupeinfo.Text} was repeated {dupeinfo.Count} times starting at index {dupeinfo.Index}");
            }
            public static IEnumerable<DupeInfo> FindRepeats(IEnumerable<string> input)
            {
                int i = 0;
                int j = 0;
                int c = -1;
                string prev = null;
                foreach (var curr in input)
                {
                    if (curr != prev)
                    {
                        if (c >= 0)
                            yield return new DupeInfo {Text = prev, Count = c + 2, Index = j};
                        c = -1;
                        j = i;
                    }
                    else
                    {
                        ++c;
                    }
                    prev = curr;
                    ++i;
                }
                if (c >= 0)
                    yield return new DupeInfo {Text = prev, Count = c + 2, Index = j};
            }
        }
    }
