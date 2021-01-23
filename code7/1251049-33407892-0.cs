        List<string> newfilename1 = new List<string>();
            using (var zip = new ZipFile())
            {
                var str = new string[] { "1250a2d5-cd40-4bcc-a979-9d6f2cd62b9fLog.txt", "bdb31966-e3c4-4344-b02c-305c0eb0fa0aLogging.txt" }; //file name are Log.txt and Logging.txt
                string[] str1 = str .Split(',');
                foreach (var item in str1)
                {
                      string filePath = Server.MapPath("~/Uploads/" + item);
                                string newFileName = Server.MapPath("~/Uploads/" + item.Substring(36));
                                newfilename1.Add(newFileName);
                                System.IO.File.Copy(filePath,newFileName);
                                zip.AddFile(newFileName,"");
                }
                zip.Save(memoryStream);
     foreach (var item in newfilename1)
                        {
                            System.IO.File.Delete(item);
                        }
            }
