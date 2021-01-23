    using Word = Microsoft.Office.Interop.Word;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    namespace TestWordLanguages
    {
        public class OfficeLanguages
        {
            private class LanguageItem
            {
                public Word.WdLanguageID Id { get; set; }
                public string Name { get; set; }
    
                public LanguageItem(Word.WdLanguageID id, string name)
                {
                    Id = id;
                    Name = name;
                }
            }
    
            List<LanguageItem> languageList = new List<LanguageItem>();
    
            public void MethodA()
            {
                Stopwatch sw1 = new Stopwatch();
                Stopwatch sw2 = new Stopwatch();
                Stopwatch sw3 = new Stopwatch();
    
                sw1.Start();
                Word.Application oWord = new Word.Application();
                Word.Document oWordDoc = new Word.Document();
    
                //Opening document here and doing stuff with it
    
                var Selection = oWordDoc.ActiveWindow.Selection;
    
                string strTgtLanguage = "Spanish (Latin America)";
    
                var test = oWord.Application.Languages;
    
                if (languageList.Count == 0)
                {
                    foreach (Word.Language item in test)
                    {
                        languageList.Add(new LanguageItem(item.ID, item.NameLocal));
                    }
                }
    
                sw1.Stop(); // End of initial setup
    
                sw2.Start(); // Current lookup - using COM everytime
                foreach (Word.Language item in test)
                {
                    if (item.NameLocal.IndexOf(strTgtLanguage) > -1)
                    {
                        Selection.LanguageID = item.ID;
                        break;
                    }
                }
                sw2.Stop();
    
                sw3.Start(); // Using stored list of languages
                Selection.LanguageID = languageList.Single(lang => lang.Name == strTgtLanguage).Id;
                sw3.Stop();
    
            }
        }
    }
