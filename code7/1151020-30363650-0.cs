    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Collections.Generic;
    public class Program
    {
	    public static void Main()
	    {
		    string[] indefinites = checkForIndefinite();
		    foreach (string s in indefinites)
		    {
			    Console.WriteLine(s);
		    }
	    }
		
        static string[] SearchKeywords(List<string> keywords, string sentence)
	    {
		    if (String.IsNullOrEmpty(sentence))
		    {
			    return null;
		    }
			
		    List<string> nouns = new List<string>();
		    string[] words = sentence.Split(' ');
		
		    foreach (string keyword in keywords)
		    {
			    for (int i = 0; i < words.Length; i++ )
			    {
				    if (words[i] == keyword)
				    {
					    if (i+1 < words.Length && !nouns.Contains(words[i+1]))
					    {
						    nouns.Add(words[i+1]);
					    }
				    }
			    }
		    }
		    return nouns.ToArray();
	    }
	
       static string[] checkForIndefinite()
       {
           string sentence = "This is not an interesting sentence to use to test a program";
           string text = string.Empty;   
           List<string> words = new List<string>();
           words.Add("an");
           words.Add("a");
	       return SearchKeywords(words, sentence);
       }
    }
