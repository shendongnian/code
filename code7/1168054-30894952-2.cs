        public void TestCallBack1(Office.IRibbonControl control)
        {
            Globals.ThisAddIn.Application.Options.AllowReadingMode = false;
            //"S:\Test doc.docx"
            Word.Document doc = Globals.ThisAddIn.Application.Documents.Open("S:\\Test doc.docx",Type.Missing,true);
            int num = doc.ComputeStatistics(Word.WdStatistic.wdStatisticPages, Type.Missing);
            int[] a = { 5, 3, 1 };
            for (int i = 0; i < a.Length; i++)
            {
                object page_num = a[i];
                Globals.ThisAddIn.Application.Selection.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, num, page_num);
                Globals.ThisAddIn.Application.Selection.Bookmarks[@"\Page"].Select();
                Globals.ThisAddIn.Application.Selection.Delete();
            }
            Globals.ThisAddIn.Application.Options.AllowReadingMode = true;
        }
