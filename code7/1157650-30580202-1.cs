    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		InsertSpaces1();
    		InsertSpaces2();
    		InsertSpaces3();
    		InsertSpaces4();
    	}
    
    	private static void InsertSpaces1()
    	{
    		Stopwatch w = new Stopwatch();
    		w.Start();
    		
    		string text = " ( ((abc ) def)ghi)";
    		text = Regex.Replace(text.Replace("(", " ( ").Replace(")", " ) "), @"[ ]{2,}", @" ");
    		Console.WriteLine(text);
    		
    		w.Stop();
    		Console.WriteLine(w.Elapsed);
    	}
    
    	private static void InsertSpaces2()
    	{
    		Stopwatch w = new Stopwatch();
    		w.Start();
    		
    		string text = " ( ((abc ) def )ghi)";
    		text = Regex.Replace(text.Replace(" ", String.Empty), "\\w+|[()]", "$0 ");
    		Console.WriteLine(text);
    		
    		w.Stop();
    		Console.WriteLine(w.Elapsed);
    	}
    
    	private static void InsertSpaces3()
    	{
    		Stopwatch w = new Stopwatch();
    		w.Start();
    		
    		StringBuilder text = new StringBuilder("( ((abc ) def )ghi)");
    		for (int i = 0; i < text.Length; i++) 
    		{
    			if (
                    // Insert a space to the left even at the beginning of the string
    				(text[i] == '(' && ((i - 1 >= 0 && text[i - 1] != ' ') || i == 0)) ||
    				(text[i] == ')' && ((i - 1 >= 0 && text[i - 1] != ' ') || i == 0))
    			   )
    			{
    				text.Insert(i, ' ');
    			} 
    			else if (
                         // Insert a space to the right
    					 (text[i] == '(' && (i + 1 < text.Length && text[i + 1] != ' ')) ||
    					 (text[i] == ')' && (i + 1 < text.Length && text[i + 1] != ' '))
    				    )
    			{
    				text.Insert(i + 1, ' ');
    			}
    			else if (
                         // Insert a space to the right even at the end
    					 (text[i] == '(' && (i + 1 == text.Length)) ||
    					 (text[i] == ')' && (i + 1 == text.Length))
    				    )
    			{
    				text.Append(" ");
    			}
    		}
    		Console.WriteLine(text);
    		
    		w.Stop();
    		Console.WriteLine(w.Elapsed);
    	}
    
    	private static void InsertSpaces4()
    	{
    		Stopwatch w = new Stopwatch();
    		w.Start();
    		
    		string text = "( ((abc ) def )ghi)";
    		for (int i = 0; i < text.Length; i++) 
    		{
    			if (
                    // Insert a space to the left even at the beginning of the string
    				(text[i] == '(' && ((i - 1 >= 0 && text[i - 1] != ' ') || i == 0)) ||
    				(text[i] == ')' && ((i - 1 >= 0 && text[i - 1] != ' ') || i == 0))
    			   )
    			{
    				text = text.Insert(i, " ");
    			} 
    			else if (
                         // Insert a space to the right
    					 (text[i] == '(' && (i + 1 < text.Length && text[i + 1] != ' ')) ||
    					 (text[i] == ')' && (i + 1 < text.Length && text[i + 1] != ' '))
    				    )
    			{
    				text = text.Insert(i + 1, " ");
    			}
    			else if (
                         // Insert a space to the right even at the end
    					 (text[i] == '(' && (i + 1 == text.Length)) ||
    					 (text[i] == ')' && (i + 1 == text.Length))
    				    )
    			{
    				text += " ";
    			}
    		}
    		Console.WriteLine(text);
    		
    		w.Stop();
    		Console.WriteLine(w.Elapsed);
    	}
    }
