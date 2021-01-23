    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using DevExpress.XtraPrinting;
    using DevExpress.XtraRichEdit;
    
    using(MemoryStream streamWithWordFileContent = new MemoryStream()) {
        //Populate the streamWithWordFileContent object with your DOC / DOCX file content
    
        RichEditDocumentServer richContentConverter = new RichEditDocumentServer();
        richContentConverter.LoadDocument(streamWithWordFileContent, DocumentFormat.Rtf);
    
        //Save
        PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
        pcl.Component = richContentConverter;
        pcl.CreateDocument();
    
        ImageExportOptions options = new ImageExportOptions(ImageFormat.Png);
    
        //Paging
        //options.ExportMode = ImageExportMode.SingleFilePageByPage;
        //options.PageRange = "1";
    
        pcl.ExportToImage(MapPath(@"~/DocumentAsImageOnDisk.png"), options);
    }
