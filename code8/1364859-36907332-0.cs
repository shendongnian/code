    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace CSharpConsoleApplication.Tests
    {
        class JustATest
        {
            public static void Run()
            {
                var list = new List<Test>();
    
                for (int i = 0; i < 1000000; i++)
                    list.Add(new Test() { Text = "a" + i.ToString().PadLeft(6, '0') });
    
    
                string input = "a011";
                List<Test> found = null;
    
    
    
    
                // Get the results with LinQ
    
                var w = new Stopwatch(); w.Start();
                found = list.Where(t => t.Text.Substring(0, 4) == input).ToList();
                w.Stop();
                Console.WriteLine("Search list with linq. Results count = {0}", found.Count);
                Console.WriteLine(w.Elapsed);
                Console.ReadLine();
    
    
    
    
                // Store data in dictionary if no refresh needed
    
                // Populate the dictionary
                var objectsDictionary = new Dictionary<string, List<Test>>();
    
                w.Restart();
                PopulateDictionary(objectsDictionary, list, input.Length);
                w.Stop();
                Console.WriteLine("Populate dictionary");
                Console.WriteLine(w.Elapsed);
                Console.ReadLine();
    
                // Search in dictionary
                w.Restart();
                if (objectsDictionary.ContainsKey(input))
                    found = objectsDictionary[input];
                //objectsDictionary[input].ForEach(t => Console.WriteLine(t.Text));
    
                w.Stop();
                Console.WriteLine("Search in dictionary. Results count = {0}", found.Count);
                Console.WriteLine(w.Elapsed);
                Console.ReadLine();
            }
    
            static void PopulateDictionary(Dictionary<string, List<Test>> dictionary, List<Test> list, int textLength)
            {
                foreach (var t in list)
                {
                    string text = t.Text.Substring(0, textLength);
    
                    if (dictionary.ContainsKey(text))
                        dictionary[text].Add(t);
                    else
                        dictionary.Add(text, new List<Test>() { t });
                }
            }
    
            class Test
            {
                public string Text { get; set; }
            }
    
        }
    }
