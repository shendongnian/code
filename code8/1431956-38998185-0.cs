    new Thread(() => 
    {
    using (StreamReader sr = File.OpenText((string)e.Argument))
    {
        string s = String.Empty;
        while ((s = sr.ReadLine()) != null)
        {
            //do your stuff here
            e.Result += s + '\n';
        }
        SomeTextBox.Dispatcher.BeginInvoke((Action)(() => SomeTextBox.Text = s;));
     }
        
    }).Start();
