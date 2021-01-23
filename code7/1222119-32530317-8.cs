    //make your event handler async
    private async void Button1_Click(object sender, EventArgs e)
    {
        string result = "";
        //await the task
        await Task.Run(() =>
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            using (WebResponse myResponse = myRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
            }
        });
        
        //The execution arrive here after running task, without freezing UI
        //MessageBox.Show(result);
        MessageBox.Show("Finished");
        //And Here you can easily set properties of form 
    }
