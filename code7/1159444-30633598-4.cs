    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
           string input = @"[Testing.User]|Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))|Description:([System.String]|This is some description)";
           string pattern = @"(?:[^|()]+|\((?>[^()]+|(?<Open>[(])|(?<-Open>[)]))*(?(Open)(?!))\))+";
           foreach (Match m in Regex.Matches(input, pattern)) 
               Console.WriteLine("{0}", m.Value);
       }
    }
