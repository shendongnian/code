    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                String[] emails = { "john.doe@domain1.com", "jane_doe@domain1.com", "patricksmith@domain2.com", "erick.brown@domain3.com" };
                var result = process(emails);
            }
    
            static String[] process(String[] emails)
            {
                String[] result = new String[emails.Length];
                var comparer = new DomainComparer();
                Array.Sort(emails, comparer);
                for (int i = 0, j = emails.Length - 1, k = 0; i < j; i++, j--, k += 2)
                {
                    if (i == j)
                        result[k] = emails[i];
                    else
                    {
                        result[k] = emails[j];
                        result[k + 1] = emails[i];
                    }
                }
    
                return result;
            }
        }
    
        public class DomainComparer : IComparer<string>
        {
            public int Compare(string left, string right)
            {
                int at_pos = left.IndexOf('@');
                var left_domain = left.Substring(at_pos, left.Length - at_pos);
                at_pos = right.IndexOf('@');
                var right_domain = right.Substring(at_pos, right.Length - at_pos);
                return String.Compare(left_domain, right_domain);
            }
        }
    }
