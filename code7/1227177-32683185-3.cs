    class Program
    {
        static void Main(string[] args)
        {
            string json = @"'Album':{
                                 'Name': 'Classical',
                                 'Date': '2005-4-7T00:00:00'
                                }";
            var album = JsonHelper.Deserialize<Album>(json);
            //or with name
            var album2 = JsonHelper.Deserialize<Album>(json,"Album");
       }
    }
