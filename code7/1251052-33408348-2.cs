    using (ZipFile zip = new ZipFile())
    {
    var str = new string[] { "1250a2d5-cd40-4bcc-a979-9d6f2cd62b9fLog.txt", "bdb31966-e3c4-4344-b02c-305c0eb0fa0aLogging.txt" };
                foreach(var item in str) {
                        string filePath = Server.MapPath("~/Uploads/" + item);
                        var content = File.ReadAllLines(filePath);
                        ZipEntry e = zip.AddEntry("files/" + item.Substring(36), content);
                    }
                }  
    zip.Save(memoryStream);
    }
