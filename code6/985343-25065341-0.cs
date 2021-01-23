                        Response.Clear();
                        Response.Buffer = True;
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", "attachment;filename=yourfile.xslx"
                        Response.BinaryWrite(YourFile);
                        Response.End();
