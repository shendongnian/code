    var bytes = System.IO.File.ReadAllBytes(fileTemporary);
    SendFileBytesToResponse(bytes, fileName);
    public static bool SendFileBytesToResponse(byte[] pdfByte, string sFileName)
            {
                if (pdfByte != null)
                {
                    string downloadName = sFileName;
                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.Clear();
                    response.AddHeader("Content-Type", "binary/octet-stream");
                    response.AddHeader("Content-Disposition",
                                       "attachment; filename=" + downloadName + "; size=" + pdfByte.Length.ToString());
                    response.Flush();
                    response.BinaryWrite(pdfByte);
                    response.Flush();
                    response.End();
                }
    
                return true;
            }
