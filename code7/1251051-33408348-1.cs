        using(var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true)) {
            {
                //using(var zip = new ZipFile()) {
                var str = new string[] { "1250a2d5-cd40-4bcc-a979-9d6f2cd62b9fLog.txt", "bdb31966-e3c4-4344-b02c-305c0eb0fa0aLogging.txt" }; //file name are Log.txt and Logging.txt
                                                                                                                                             //string[] str = str.Split(',');
                foreach(var item in str) {
                    using(var entryStream = archive.CreateEntry("files/" + item.Substring(36)).Open()) {
                        string filePath = Server.MapPath("~/Uploads/" + item);
                        var content = File.ReadAllBytes(filePath);
                        entryStream.Write(content, 0, content.Length);
                    }
                }
            }
        }
