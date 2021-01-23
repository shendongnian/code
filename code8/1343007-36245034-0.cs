    protected void ZipDownload()
        {
            var list = //query for getting the files.
            ZipFile zip = new ZipFile();
            foreach (var file in list)
            {
    
                zip.AddEntry(file.docname, (byte[])file.doc.ToArray());
            }
            var zipMs = new MemoryStream();
            zip.Save(zipMs);
            byte[] fileData = zipMs.GetBuffer();
            zipMs.Seek(0, SeekOrigin.Begin);
            zipMs.Flush();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=docs.zip ");
            Response.ContentType = "application/zip";
            Response.BinaryWrite(fileData);
            Response.End();
    
        }
