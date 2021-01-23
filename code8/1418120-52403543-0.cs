     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Xceed.Words.NET;
    using System.Diagnostics;
    using System.IO;
    
    namespace MVC_WordDocument.Controllers
    {
        public class GenerateDocumentController : Controller
        {
            // GET: GenerateDocument
            public ActionResult GenerateDocument()
            {
                return View();
            }
            [HttpPost]
            public void GenerateDocument(string generate)
            {
                DocX doc = null;
    
                doc = DocX.Create(Server.MapPath("~/ StudentInformation.docx"), DocumentTypes.Document);
    
                string Text = @"Student Information";
                doc.InsertParagraph(Text, false).Alignment = Alignment.both;
                doc.InsertParagraph(" ");
    
                Table table = doc.AddTable(8, 7);
                table.Alignment = Alignment.center;
                table.Design = TableDesign.LightGridAccent2;
    
                table.Rows[0].Cells[0].Paragraphs.First().Append("Student Number");
                table.Rows[0].Cells[1].Paragraphs.First().Append("Name");
                table.Rows[0].Cells[2].Paragraphs.First().Append("Surname");
                table.Rows[0].Cells[3].Paragraphs.First().Append("Email");
                table.Rows[0].Cells[4].Paragraphs.First().Append("Telephone No:");
                table.Rows[0].Cells[5].Paragraphs.First().Append("Mobile Number");
                table.Rows[0].Cells[6].Paragraphs.First().Append("Active");
    
                doc.InsertTable(table);
                doc.Save();
    
    
                MemoryStream ms = new MemoryStream();
                doc.SaveAs(ms);
                byte[] byteArray = ms.ToArray();
                ms.Flush();
                ms.Close();
                ms.Dispose();
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=StudentINFO.docx");
                Response.AddHeader("Content-Length", byteArray.Length.ToString());
                Response.ContentType = "application/msword";
                Response.BinaryWrite(byteArray);
                Response.End();
            }
        }
    }
