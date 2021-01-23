    void MyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "notepad.exe";
            p.StartInfo.CreateNoWindow = false;
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(myProcess_Exited);
            p.Start();
        }
