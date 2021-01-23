     //// Upload api written in expressjs.
   
     var apiUpload = "http://localhost:3000/upload";
                var filePath =Server.MapPath("~/App_Data/1023.jpg");
                using (var client = new WebClient())
                {
                    var responseBytes = client.UploadFile(apiUpload, "POST", filePath);
                    var result = System.Text.Encoding.UTF8.GetString(responseBytes);
                }
