       using System;
        [AttributeUsage(AttributeTargets.All)]
          public class Global : System.Attribute
           {
            public string Url;
            
            public Global(string url)   // url is a positional parameter
            {
            this.Url = url;
            }
          }
           [HelpAttribute("Information on the class MyClass")]
            class YourClass
           {
           }
   
       namespace AttributeAppl
      {
       class Program
       {
        static void Main(string[] args)
        {
         System.Reflection.MemberInfo info = typeof(MyClass);
         object[] attributes = info.GetCustomAttributes(true);
          Global dbi = (Global )Url;
        }
      }
    }
