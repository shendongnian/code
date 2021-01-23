    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        // your original function, nothing changed
        public static string GetDrawing(Dictionary<string, List<string>> AllDrawings, Dictionary<string, bool> ImportData, string[] ItemsToCompare)
        {
            string FinalDrawing = "";
            try
            {
                List<string> AllCorrect = new List<string>();
                foreach (var item in ImportData)
                {
                    if (item.Value == true && ItemsToCompare.Contains(item.Key))
                        AllCorrect.Add(item.Key);
                }
    
                AllCorrect.Sort();
    
                foreach (var DrawItem in AllDrawings)
                {
    
                    DrawItem.Value.Sort();
                    var match = AllCorrect.SequenceEqual(DrawItem.Value);
    
                    if (match == true)
                    {
                        FinalDrawing = DrawItem.Key;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return FinalDrawing;
        }
    
            public static void Main(string[] args)
            {
                var allDrawings = new Dictionary<string, List<string>>();
                allDrawings.Add("aaa", new List<string>{ "a03", "a01", "a02" }); // originally unsorted
                allDrawings.Add("bbb", new List<string>{ "b03", "b01", "b02" }); // originally unsorted
                allDrawings.Add("ccc", new List<string>{ "c03", "c01", "c02" }); // originally unsorted
     
                var import = new Dictionary<string, bool>();
                import.Add("b01", false); // falsey
                import.Add("a05", true); // not in comparison
                import.Add("a03", true);
                import.Add("c01", false); // falsey
                import.Add("a02", true);
                import.Add("a04", true); // not in comparison
                import.Add("a01", true);
     
                var toCompare = new string[9];
                toCompare[0]="a01"; toCompare[1]="a02"; toCompare[2]="a03";
                toCompare[3]="b01"; toCompare[4]="b02"; toCompare[5]="b03";
                toCompare[6]="c01"; toCompare[7]="c02"; toCompare[8]="c03";
                
                var result = GetDrawing(allDrawings, import, toCompare);
                
                Console.WriteLine("Result: " + result);
            }
    }
