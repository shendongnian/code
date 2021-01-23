    static void RunWordExample()
    {
        Word.Application oWord = new Word.Application(); //Create an instance of Microsoft Word
        //Create a new Document
        object oMissing = Missing.Value;
        Word.Document oTgtDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        //make Word visible
        oWord.Visible = true;
        // get number of pages
        Console.WriteLine("doc {0} has {1} page(s)", oTgtDoc.Name, MyWordHelpers.GetBuiltInDocumentProperty(oTgtDoc,"Number of Pages"));
        Console.ReadLine();
    }
