    using System;
    using System.Reflection;
    using Word = Microsoft.Office.Interop.Word;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {    
                RunWordExample();
            } 
    
    
            static void RunWordExample()
            {
                Word.Application oWord = new Word.Application(); //Create an instance of Microsoft Word
    
                //Create a new Document
                object oMissing = Missing.Value;
                Word.Document oTgtDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    
                //make Word visible
                oWord.Visible = true;
    
                // get number of pages #1
                var PgNum = oTgtDoc.BuiltInDocumentProperties(Word.WdBuiltInProperty.wdPropertyPages).Value.ToString();
                Console.WriteLine("doc {0} has {1} page(s)", oTgtDoc.Name, PgNum);
                Console.ReadLine();
    
            }
    
        }
    }
