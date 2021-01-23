    private async void YourMethod()
    {
        //first part of your code here.
        
        await Task.Run(() =>
        {
            for (int i = 0; i < split.Length; i++)
            {
               linkRange = richEditControl1.Document.AppendText(split[i] + "\n\n");
               hyperlink = richEditControl1.Document.CreateHyperlink(linkRange);
            }
        });
    }
