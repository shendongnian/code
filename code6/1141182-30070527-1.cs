    using System;
    using System.Collections.Generic;
					
    public class Program
    {
    	public static void Main()
    	{
            // Added the word 'is' multiple times for demonstration
    		string input = "To be or not to that is is is is is is is the question";
    		
		    string output = FindUniqueWords(input);
		    Console.WriteLine(output);
	    }
	
	    private static string FindUniqueWords(string text)
	    {
		    Dictionary<string, int> dictionary = new Dictionary<string, int>();
	
		    string uniqueWords = "";
		    text = text.Replace(",", ""); //Just cleaning up a bit
		    text = text.Replace(".", ""); //Just cleaning up a bit
		    string[] arr = text.Split(' '); //Create an array of words
	
		    foreach (string word in arr) //let's loop over the words
		    {
			    if (dictionary.ContainsKey(word)) //if it's in the dictionary
			    	dictionary[word] = dictionary[word] + 1; //Increment the count
			    else
			    	dictionary[word] = 1; //put it in the dictionary with a count 1
		    }
	
		    foreach (KeyValuePair<string, int> pair in dictionary) //loop through the dictionary
		    {
			    uniqueWords += (pair.Key + " ");
		    }
		
		    return (uniqueWords);
	    }
    }
