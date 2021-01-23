    using System;
    using System.Collections.Generic;
    
    public class Program
    {
	   public static void Main()
	   {
	      string expression = "( a[i]+{-1}*(8-9) ) ";
		  bool stackResult = checkValidity(expression);
		  
          if (stackResult)
             Console.WriteLine("Expression is Valid.");
          else
             Console.WriteLine("\nExpression is not valid.");
       }
       private static bool checkValidity(string expression)
       {
          Stack<char> openStack = new Stack<char>();
          foreach (char c in expression)
          {
             switch (c)
             {
                case '{':
                case '(':
                case '[':
                   openStack.Push(c);
                   break;
                case '}':
                   if (openStack.Count == 0 || openStack.Peek() != '{')
                   {
                      return false;
				   }
                   openStack.Pop();		  
                   break;
                case ')':
                   if (openStack.Count == 0 || openStack.Peek() != '(')
                   {
                      return false;
                   }
                   openStack.Pop();		  
                   break;
                case ']':
                   if (openStack.Count == 0 || openStack.Peek() != '[')
                   {
                      return false;
                   }
                   openStack.Pop();		  
                   break;
                default:
                   break;
             }
          }
          return openStack.Count == 0;
       }
    }
