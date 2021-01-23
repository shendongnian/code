    Task.Factory.StartNew(() =>
    {
        //access the URLs in a suitable interval and process data
        File.WriteAllText("data.txt",rootObject.timeSinceStartup.ToString());
        //access the URLs in a suitable interval and process data
        File.WriteAllText("data2.txt",rootObject.timeSinceStartup.ToString());
        string ex = File.ReadAllText("data.txt") + "/n" + File.ReadAllText("data2.txt")... ;
        txtOut.Text = ex;    
    });
