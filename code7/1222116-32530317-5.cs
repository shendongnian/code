    string url= "http://www.google.com";
    string result = "";
    Task.Run(() =>
    {
        HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
        using (WebResponse myResponse = myRequest.GetResponse())
        {
            using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result = sr.ReadToEnd();
            }
        }
    }).ContinueWith(x =>
    {
        //MessageBox.Show(result);
        MessageBox.Show("Finished");
        //here you can not easily set properties of form 
        //you should use Invoke pattern
    });
