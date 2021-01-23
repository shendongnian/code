    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
             string imageloc = @"D:\Image";
             string[] files = Directory.GetFiles(imageloc);
             foreach (string file in files)
             {
                 System.Threading.Thread.Sleep(1000);
                 // Any UI control which you want to use within thread,
                 // you need Invoke using UI thread. I have declare a method below
    
                 ExecuteSecure(() =>label1.Text = "File Scanning--> " + file);
                 System.Threading.Thread.Sleep(3000);
                 ExecuteSecure(() =>label1.Text = "");
    
             }          
        });
        
    }    
    //---
    private void ExecuteSecure(Action action)
    {
        if (InvokeRequired)
        {
            Invoke(new MethodInvoker(() => action()));
        }
        else
        {
            action();
        }
    }
