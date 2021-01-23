    Application pptApplication = new Application();
    Microsoft.Office.Interop.PowerPoint.Presentation pptPresentation = pptApplication.Presentations.Open2007(Server.MapPath("~/tempslides/pptfilename.pptx"), MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
    List<string> files = new List<string>();
    for (int i = 1; i <= pptPresentation.Slides.Count; i++)
    {
        pptPresentation.SaveCopyAs(serverPath + randomId, PpSaveAsFileType.ppSaveAsPNG, MsoTriState.msoTrue);
        files.Add(Server.MapPath("~/tempslides") + "/slide" + i + ".PNG");
    }
    pptPresentation.Close();
