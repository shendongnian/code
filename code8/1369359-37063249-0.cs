    <%@ WebHandler Language="C#" Class="MergeFiles" %>
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.IO; 
    using iTextSharp.text; 
    using iTextSharp.text.pdf; 
    
    public class MergeFiles : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            List<byte[]> pdfs = new List<byte[]>();
            var pdf = File.ReadAllBytes(context.Server.MapPath("~/app_data/test.pdf"));
            for (int i = 0; i < 4000; ++i) pdfs.Add(pdf);
    
            var Response = context.Response;
            Response.ContentType = "application/pdf";
            Response.AddHeader(
                "content-disposition",
                "attachment; filename=MergeLotsOfPdfs.pdf"
            );
            Response.BinaryWrite(MergeLotsOfPdfs(pdfs));
        }
    
        byte[] MergeLotsOfPdfs(List<byte[]> pdfs)
        {
            using (var ms = new MemoryStream())
            {
                using (Document document = new Document())
                {
                    using (PdfCopy copy = new PdfCopy(document, ms))
                    {
                        document.Open();
                        for (int i = 0; i < pdfs.Count; ++i)
                        {
                            using (PdfReader reader = new PdfReader(
                                new RandomAccessFileOrArray(pdfs[i]), null))
                            {
                                copy.AddDocument(reader);
                                copy.FreeReader(reader);
                            }
                        }
                    }
                }
                return ms.ToArray();
            }
        }
    
        public bool IsReusable { get { return false; } }
    }
