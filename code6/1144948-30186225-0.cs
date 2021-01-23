    class myClass
    {
      static void Main(string[] args)
      {
       Task<ReadFileResult> task = Task<ReadFileResult>.Factory.StartNew(() =>
        {
           string url = "URL";
           return readFile(url));
        });
       ReadFileResult outcome = task.Result;
      }
      private static ReadFileResult readFile(string url)
      {           
        ReadFileResult r = new ReadFileResult();
        r.isSuccessFull = true;
        return r;
      }
    }
    class ReadFileResult
    {
         public bool isSuccessFull { get; set; }
    }
