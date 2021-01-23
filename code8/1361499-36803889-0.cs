    using System;
    using System.Globalization;
    public class Example
    {
        public static void Main()
    {
      string[] values = { "a tale of two cities", "gROWL to the rescue",
                          "inside the US government", "sports and MLB baseball",
                          "The Return of Sherlock Holmes", "UNICEF and         children"};
      TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
      foreach (var value in values)
         Console.WriteLine("{0} --> {1}", value, ti.ToTitleCase(value));
       }
    }
