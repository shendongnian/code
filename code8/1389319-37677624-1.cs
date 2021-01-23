    using System;
    using System.Text.RegularExpressions;
    
    public class Example {
        public static void Main() {
            string[] inputs = {
                "Überbrückerstraße 24a",
                "34 Street Blah Blah",
                "Hallgartenerstrasse Moritzstr.",
                "Ueckerstr. 20 b"
            };
            foreach (string input in inputs) {
                string pat = @"(?<=^\d[^ ]*) | (?=\d)";
                string[] matches = Regex.Split(input, pat);
                foreach (string match in matches) {
                    Console.Write("<{0}>", match);
                }
                Console.Write("\n");
            }
        }
    }
