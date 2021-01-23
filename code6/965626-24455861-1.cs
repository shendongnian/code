    async void TestMethod()
    {
        Task.Run(() =>
        {
            var host = new WebServiceHost(typeof(MyContract), new Uri("http://0.0.0.0:8088/Test"));
            host.Open();
        });
        await Task.Delay(2000);
        new Webclient().UploadData("http://localhost:8088/Test/UploadImage/abc.bmp", new byte[] { 65, 66, 67, 68, 69 });
    }
    [ServiceContract]
    class MyContract 
    {
        [OperationContract, WebInvoke(UriTemplate = "/UploadImage/{name}")]
        public void UploadImage(Stream s, string name)
        {
            Console.WriteLine(name  +  " -> " + new StreamReader(s).ReadToEnd());
        }
    }
