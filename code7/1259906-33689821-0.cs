    public static int Main()
    {
         List<DocPart> Parts = new List<DocPart>();
         var doc = new DocConfig();
         doc.Description = "bla bla";
         doc.Parts = new List<DocPart>();
         doc.Parts.Add(new DocPart { Title = "aaa", TexLine = @"\include{aaa.tex}" });
         doc.Parts.Add(new DocPart { Title = "bbb", TexLine = @"\include{bbb.tex}" });
         foreach (DocPart part in doc.Parts)
         {
               Console.WriteLine(part.Title);
               {
                     Console.ReadLine();
                     return 0;
               }
         }
         return -1;
    }
