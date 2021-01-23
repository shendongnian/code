    new Thread(delegate ()
    {
        while (!DL.HasExited)
        {
            Thread.Sleep(500);
        }
    
        File.Delete(folderBrowserDialog1.SelectedPath + @"\Steam\steamcmd.zip");
        //The code below this note is the problem
        button1.BeginInvoke(()=>{
            button1.Text = "START DOWNLOADING";
            button1.Enabled = true;
        });
                    
    }).Start();
