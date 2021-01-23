    namespace ConsoleApplication3
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        internal class Program
        {
            #region Methods
    
            private static void Main(string[] args)
            {
                #region data
    
                var data = new List<FormData>
                           {
                               new FormData
                               {
                                   FormId = 1,
                                   FormFieldId = 1,
                                   ResponseId = 1,
                                   Response = "Response to Q1."
                               },
                               new FormData
                               {
                                   FormId = 1,
                                   FormFieldId = 2,
                                   ResponseId = 2,
                                   Response = "Response to Q2."
                               },
                               new FormData
                               {
                                   FormId = 2,
                                   FormFieldId = 1,
                                   ResponseId = 10,
                                   Response = "2nd Response to Q1."
                               },
                               new FormData
                               {
                                   FormId = 2,
                                   FormFieldId = 2,
                                   ResponseId = 11,
                                   Response = "2nd Response to Q2."
                               },
                               new FormData
                               {
                                   FormId = 3,
                                   FormFieldId = 1,
                                   ResponseId = 20,
                                   Response = "3rd Response to Q1."
                               },
                               new FormData
                               {
                                   FormId = 3,
                                   FormFieldId = 2,
                                   ResponseId = 21,
                                   Response = "3rd Response to Q2."
                               },
                           };
    
                #endregion
    
                var groups = data.GroupBy(g => g.FormFieldId).Select(
                    s => new
                         {
                             s.Key,
                             Answers = s.Select(s2 => s2.Response).ToList()
                         }).ToList();
                Console.WriteLine(String.Concat(groups.Select(g => "Q" + g.Key.ToString("###").PadRight(29))));
                int maxRows = groups.Max(m => m.Answers.Count);
                for (int i = 0; i < maxRows; i++)
                {
                    Console.WriteLine(String.Concat(groups.Select(s1 => (i < s1.Answers.Count ? s1.Answers[i] : string.Empty).PadRight(30))));
                }
            }
    
            #endregion
    
            private class FormData
            {
                #region Public Properties
    
                public int FormFieldId { get; set; }
    
                public int FormId { get; set; }
    
                public string Response { get; set; }
    
                public int ResponseId { get; set; }
    
                #endregion
            }
        }
    }
