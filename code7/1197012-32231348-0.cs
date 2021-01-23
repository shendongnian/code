        private void downloadByteStreamAsFile(Byte[] bytes, String fileName)
        {
            fileName = fileName.Replace(" ", "_");
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
           if( fileName.Contains(".pdf")){
                fileName = HttpUtility.UrlEncode(fileName);
                //response.Flush(); //comment this or else no file returned
                response.AddHeader("Content-Type", "application/pdf");
                response.AddHeader("Content-Disposition",
                    "attachment; filename=" + fileName + "; size=" + bytes.Length.ToString());
                response.BinaryWrite(bytes);
                response.Flush();
                response.End();
            } else {
                //response.Flush(); //comment this or else no file returned
                response.AddHeader("Content-Type", "binary/octet-stream");
                response.AddHeader("Content-Disposition",
                    "attachment; filename=" + fileName + "; size=" + bytes.Length.ToString());
                response.BinaryWrite(bytes);
                response.Flush();
                response.End();
            }
        }
