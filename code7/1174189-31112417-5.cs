    private static string[] ReadUrlList(string path)
    {
        return File.ReadAllLines(@"c:\data\temp.txt");
    }
    private void ProcessUrl(string url)
    {
        ProcessResponse(response =>
        {
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
           {
                // Do your stuff
            
                // We're working on separate threads, to access UI we
                // have to dispatch the call to UI thread. Note that
                // code will be executed asynchronously then local
                // objects may have been disposed!
                BeginInvoke(new MethodInvoker(delegate 
                {
                    textBox1.Text += ".";
                }));
            }
        });
    } 
    
