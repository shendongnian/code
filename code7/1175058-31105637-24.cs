    private async void YourMethod()
    {
            //...
            for (int i = 0; i < split.Length; i++)
            {
               linkRange = richEditControl1.Document.AppendText(split[i] + "\n\n");
               hyperlink = richEditControl1.Document.CreateHyperlink(linkRange);
               await Task.Delay(50); // wait a moment here so win can perform other operations and will not freeze.
            }
    }
