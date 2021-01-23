    public class RawData
    {
        public string Name;
        public ChunkedList Data = new ChunkedList();
    }
    
    var list = new List<RawData>();
    for (int i = 0;; i++)
    {
        var raw = new RawData { Name = "Test" + i };
        for (int j = 0; j < 20 * 1000 * 1000; j++)
        {
            raw.Data.Add(0.1f);
        }
        list.Add(raw);
    }
