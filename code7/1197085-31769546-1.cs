    public async Task saveToXml(){
        string directory = @"C:\Users\PC-User\Documents\Link" + newURL.name + ".xml";
        await Task.Run(()=>
        {
            Task.Yield();
            using (var file = File.Create(directory))
            {
                xml.Serialize(file, url);
            }
        });
    }
