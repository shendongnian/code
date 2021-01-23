    // URL that generated this code:
    // http://txt2re.com/index-csharp.php3?s=15300504579PRI03%20&1&4&5
    
    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          string txt="15300504579PRI03 ";
    
          string re1="(\\d+)";	// Integer Number 1
          string re2="((?:[a-z][a-z]+))";	// Word 1
          string re3="(\\d+)";	// Integer Number 2
    
          Regex r = new Regex(re1+re2+re3,RegexOptions.IgnoreCase|RegexOptions.Singleline);
          Match m = r.Match(txt);
          if (m.Success)
          {
                String int1=m.Groups[1].ToString();
                String word1=m.Groups[2].ToString();
                String int2=m.Groups[3].ToString();
                Console.Write("("+int1.ToString()+")"+"("+word1.ToString()+")"+"("+int2.ToString()+")"+"\n");
          }
          Console.ReadLine();
        }
      }
    }
    
    //-----
    // Paste the code into a new Console Application
    //-----
