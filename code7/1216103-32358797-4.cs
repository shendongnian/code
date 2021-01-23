    class MessageModel
    {
        public string MessageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Fileid { get; set; }
        public string FileName { get; set; }
        public MessageModel(string m, string t, string c, string f, string f2)
        {
            MessageId = m;
            Title = t;
            Content = c;
            Fileid = f;
            FileName = f2;
        }
    }
    class HistoryModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<File> Files { get; set; }
    }
    class File
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<MessageModel> messages = new List<MessageModel>();
            messages.Add(new MessageModel("100", "1st title", "1st content", "1", "User.pdf"));
            messages.Add(new MessageModel("100", "1st title", "1st content", "2", "Log.txt"));
            messages.Add(new MessageModel("100", "1st title", "1st content", "3", "manual.doc"));
            messages.Add(new MessageModel("101", "2nd title", "2nd content", "4", "dummy.txt"));
            messages.Add(new MessageModel("102", "3rd title", "3rd content", null, null));
            messages.Add(new MessageModel("103", "4th title", "4th content", null, null));
            
            var history = messages.GroupBy(m => new { m.Title, m.Content }, (group, data) => new HistoryModel()
            {
                Title = group.Title,
                Content = group.Content,
                Files = data.Select(k => new File()
                {
                    FileId = k.Fileid,
                    FileName = k.FileName
                }).ToList(),
            });
            foreach (var h in history)
            {
                Console.WriteLine(h.Title + " " + h.Content);
                foreach (var file in h.Files)
                {
                    Console.WriteLine("\t" + file.FileId + " " + file.FileName);
                }
            }
            Console.ReadLine();
        }
        
    }
