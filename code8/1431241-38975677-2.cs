    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string body = "<div>some text</div>\r\n<div>some more text</div>";
    
            string pattern = @"<div[^>]*?>(.*?)</div>";
            string[] bodyParagraphsnew = Regex.Split(body, pattern, RegexOptions.None);
            Console.WriteLine("num of paragraph =" + bodyParagraphsnew.Length);
            for (int i = 0; i < bodyParagraphsnew.Length; i++)
            {
                Console.WriteLine("bodyParagraphs {0}: '{1}'", i, bodyParagraphsnew[i]);
            }
        }
    }
