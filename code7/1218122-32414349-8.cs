    var bytes = System.IO.File.ReadAllBytes(fileTemporary);
    SendFileBytesToResponse(bytes, fileName);
    public static bool SendFileBytesToResponse(byte[] bytes, string sFileName)
            {
                if (bytes!= null)
                {
                    string downloadName = sFileName;
                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.Clear();
                    response.AddHeader("Content-Type", "binary/octet-stream");
                    response.AddHeader("Content-Disposition",
                                       "attachment; filename=" + downloadName + "; size=" + bytes.Length.ToString());
                    response.Flush();
                    response.BinaryWrite(bytes);
                    response.Flush();
                    response.End();
                }
    
                return true;
            }
