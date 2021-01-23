            wd.Application oWord = new wd.Application();
            wd.Document oWordDoc = new wd.Document();
            wd.Selection oWordSelection = oWordDoc.ActiveWindow.Selection;
            // foreach loop
            foreach (wd.Language item in oWord.Languages)
            {
                Console.WriteLine(item.ID);
                if (item.NameLocal.IndexOf("Hungarian") > -1)
                {
                    oWordSelection.LanguageID = item.ID;
                    break;
                }
            }
            // linq
            if (oWord.Languages.Cast<wd.Language>().Any(lang => lang.NameLocal.IndexOf("Hungarian") > -1))
                oWordSelection.LanguageID = wd.WdLanguageID.wdHungarian;
