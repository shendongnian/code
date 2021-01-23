    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Word = Microsoft.Office.Interop.Word;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Object oMissing = System.Reflection.Missing.Value;
                Object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
    
                //OBJECTS OF FALSE AND TRUE
                Object oTrue = true;
                Object oFalse = false;
    
    
                //CREATING OBJECTS OF WORD AND DOCUMENT
                Word.Application oWord = new Word.Application();
                
                var test = oWord.Application.Languages;
    
                foreach (var item in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
                {
                    if (LanguageList._languageList.SingleOrDefault(i => i.Id.Equals(item.LCID)) != null)
                    {
                        Debug.WriteLine(LanguageList._languageList.SingleOrDefault(i => i.Id.Equals(item.LCID)).Name +
                            " -- " +
                            item.EnglishName +
                            " -- " +
                            ((int)item.LCID).ToString()
                        );
                    }
                    else if (LanguageList._languageList.SingleOrDefault(i => i.Id.Equals(item.Parent.LCID)) != null)
                    {
                        Debug.Indent();
                        Debug.WriteLine("-------- PARENT MATCH: " + item.EnglishName + " -- " + ((int)item.Parent.LCID).ToString());
                        Debug.Unindent();
                    }
                    else
                    {
                        Debug.Indent();
                        Debug.WriteLine("!!!!!!!! NO MATCH: " + item.EnglishName + " -- " + ((int)item.LCID).ToString());
                        Debug.Unindent();
                    }
                }
                
            }
        }
