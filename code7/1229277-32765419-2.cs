    string oldFile = "Tmp.pdf";
    string newFile = nomFichier = DateTime.Now.ToString().
                                  Substring(0,10).Replace('/','-') + 
                                  "_" + salarie.NOM + "_" + salarie.PRENOM;
    string ext = ".pdf";
    string folderName = "FICHE_EPI";
    
    //Si le tableau est trop bas pour faire passer la signature
    if (availableSpace < 90) 
    {
        var tempFileLocation = @"Tmp2.pdf";
        var bytes = File.ReadAllBytes(@"Tmp.pdf");
    
        using (var reader1 = new PdfReader(bytes))
        {
            var numberofPages = reader1.NumberOfPages;
            var pages = 1;
    
            if (pages != 0)
            {
                using (var fileStream = new FileStream(
                       tempFileLocation, 
                       FileMode.Create, 
                       FileAccess.Write))
                {
                    using (var stamper = new PdfStamper(reader1, fileStream))
                    {                                            
                        var rectangle = reader1.GetPageSize(1);
                        for (var i = 1; i <= pages; i++)
                            stamper.InsertPage(numberofPages + i, rectangle);
                    }
                }
            }
        }
        File.Delete(@"Tmp.pdf");
        File.Move(tempFileLocation, @"Tmp.pdf");
