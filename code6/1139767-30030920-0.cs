            public class WordController : Controller
            {
                public void Download()
                {
                    byte[] toArray = null;
                    Document doc = new Document();
                    Paragraph test = doc.AddSection().AddParagraph();
                    test.AppendText("This is a test");
                    using (MemoryStream ms1 = new MemoryStream())
                    {
                        doc.SaveToStream(ms1, FileFormat.Doc);
                        //save to byte array
                        toArray = ms1.ToArray();
                    }
                    //Write it back to the client
                    Response.ContentType = "application/msword";
                    Response.AddHeader("content-disposition", "attachment;  filename=Doc.doc");
                    Response.BinaryWrite(toArray);
                    Response.Flush();
                    Response.End();
                }
            }
