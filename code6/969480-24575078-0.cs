    public ActionResult DownloadFile()
        {
            string string1 = "value1, value2, value3, value4";
            string string2 = "value10, value20, value30, value40";
            List<String> files =  new List<String>();
            files.Add(string1);
            files.Add(string2);
            byte[] buffer = CompressStringToFile("myfile.zip", files);
            return File(buffer, "application/zip");
        }
    private byte[] CompressStringToFile(string fileName, List<string> content)
        {
            byte[] result = null;
            int count = 0;
            using (var ms = new MemoryStream())
            {
                using (var s = new ZipOutputStream(ms))
                {
                    foreach (string str in content)
                    {
                        s.PutNextEntry(String.Format("entry{0}.txt", count++));
                        byte[] buffer = Encoding.UTF8.GetBytes(str);
                        s.Write(buffer, 0, buffer.Length);
                    }
                }
                result = ms.ToArray();
            }
            return result;
        }
