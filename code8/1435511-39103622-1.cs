    [WebMethod]
    public static void savepdfFiles(List<PdfFile> listPdf)
    {
        //code
        foreach (var item in listPdf)
        {
            byte[] data = Convert.FromBase64String(item.B64Data);
            System.IO.File.WriteAllBytes(string.Format("d:\\temp\\{0}",item.FileName), data) ;
        }
    
    }
