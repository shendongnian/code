    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    
    namespace TestStuff
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "<p>this is my string.</p><p>my string is html with tags and <a href=&quot;someurl&quot;>links</a>&nbsp;and&nbsp;encoding.</p><p>i want to&nbsp;find&nbsp;a&nbsp;substring but my comparison might not have tags &amp; encoding.";
                s = "i want to&nbsp;find&nbsp;a&nbsp;substring";
    
                string comparison = "i want to find a substring";
    
                string decode = HttpUtility.HtmlDecode(s);
                string tagsreplaced = Regex.Replace(decode, "<.*?>", " ");
                string normalized = tagsreplaced.Normalize();
    
                Console.WriteLine("Dumping first string");
                Console.WriteLine(normalized);
                Console.WriteLine(BitConverter.ToString(Encoding.UTF8.GetBytes(normalized)));
    
                Console.WriteLine("Dumping second string");
                Console.WriteLine(comparison);
                Console.WriteLine(BitConverter.ToString(Encoding.UTF8.GetBytes(comparison)));
    
                if (normalized.IndexOf(comparison) != -1)
                    Console.WriteLine("substring found");
                else
                    Console.WriteLine("substring not found");
                Console.ReadLine();
                return;
            }
        }
    }
