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
                string aux1 = "";
                string siteMap = "<? xml version = \"1.0\" encoding = \"UTF-8\" ?>";
                siteMap += "<Root>";
                List<string> Niveau1Titles = getNiveau1Titles(aux1);
                List<List<Couple>> Niveau2Titles = getNiveau2Titles(aux1);
                int i = 0;
                foreach (var n2 in Niveau2Titles)
                {
                    siteMap += "<Niveau_1 Title = \"" + Niveau1Titles[i] + "\" >";
                    foreach (var n22 in n2)
                    {
                        siteMap += "<Niveau_2 Title = \"" + n22.Title + "\" Link = \"" + n22.Link + "\" >";
                        List<Couple> Niveau3Titles = new List<Couple>();
                        Niveau3Titles = getNiveau3Titles(n22.Link);
                        foreach (var n3 in Niveau3Titles)
                        {
                            siteMap += "<Niveau_3 Title = \"" + n3.Title + "\" Link = \"" + n3.Link + "\" />";
                        }
                        siteMap += "</Niveau_2>";
                    }
                    siteMap += "</Niveau_1>";
                    i++;
                }
                siteMap += "</Root>";
                Console.WriteLine(siteMap);
                Console.ReadLine();
            }
            static List<string> getNiveau1Titles(string aux1)
            {
                return new List<string> { "aaa", "aab", "aac", "aad" };
            }
            static List<List<Couple>> getNiveau2Titles(string aux1)
            {
                return new List<List<Couple>>() { 
                      new List<Couple>() {new Couple() { Title = "T11", Link =  "L11"}, new Couple() { Title = "T12", Link =  "L12"}, new Couple() { Title = "T13", Link =  "L13"} },
                      new List<Couple>() {new Couple() { Title = "T21", Link =  "L21"}, new Couple() { Title = "T22", Link =  "L22"}, new Couple() { Title = "T23", Link =  "L23"} },
                      new List<Couple>() {new Couple() { Title = "T31", Link =  "L31"}, new Couple() { Title = "T32", Link =  "L32"}, new Couple() { Title = "T33", Link =  "L33"} },
                      new List<Couple>() {new Couple() { Title = "T41", Link =  "L41"}, new Couple() { Title = "T42", Link =  "L42"}, new Couple() { Title = "T43", Link =  "L43"} }
                };
            }
            static List<Couple> getNiveau3Titles(string aux1)
            {
                return new List<Couple>() { new Couple() { Title = "T100", Link = "L100" }, new Couple() { Title = "T101", Link = "L101" }, new Couple() { Title = "T102", Link = "L102" } };
            }
        }
        public class Couple
        {
            public string Title { get; set; }
            public string Link { get; set; }
        }
    }
    ​
