    public void SO32070323()
    {
        var file = new FileInfo(@"J:\Projects\XibisAutoGenTests\IansAwesomeSite\private\test.pdf");
    
        Response.AddHeader("Content-Disposition", "inline;filename=somefile.pdf");
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.Flush();
        Thread.Sleep(5000);
    
        Response.TransmitFile(file.FullName);
    
    }
