    public class FileData
    {
        public string ID { get; set; }
        public string IDNum { get; set; }
        public string Date { get; set; }
        public string Data { get; set; }
        public string SomeDate { get; set; }
        public string TranCode { get; set; }
    }
    public class ReadFile
    {
        public string SampleFile = @"C:\test\sample.txt";
        public ReadFile()
        {
            StreamReader reader = new StreamReader(SampleFile);
            string sampleFile = reader.ReadToEnd();
            reader.Close();
            string[] lines = sampleFile.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string previousDate = "";
            List<FileData> fileDatas = new List<FileData>();
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                FileData data = new FileData();
                string[] columns = lines[i].Split('|');
                data.ID = columns[0].Trim();
                data.IDNum = columns[1].Trim();
                data.Date = columns[2].Trim();
                data.Data = columns[3].Trim();
                string someDate = columns[4].Trim();
                if (someDate.Equals(""))
                {
                    data.SomeDate = previousDate;
                }
                else
                {
                    previousDate = someDate;
                    data.SomeDate = someDate;
                }
                data.TranCode = columns[5].Trim();
                fileDatas.Add(data);
            }
        }
    }
