    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();
            data["Dado 1"] = 1;
            data["Dado 2"] = 2;
            data["Dado 3"] = 3;
    
            var dcjs = new DataContractJsonSerializer(typeof(Data));
            MemoryStream stream1 = new MemoryStream();
            dcjs.WriteObject(stream1, data);
            stream1.Seek(0, SeekOrigin.Begin);
            var json3 = new StreamReader(stream1).ReadToEnd();
        }
    }
