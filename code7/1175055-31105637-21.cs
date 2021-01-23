        Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < split.Length; i++)
            {
    	this.BeginInvoke(new InvokeDelegate((Action)(() =>
        {
                linkRange = richEditControl1.Document.AppendText(split[i] + "\n\n");
                hyperlink = richEditControl1.Document.CreateHyperlink(linkRange);
        })));
            }
        });
    
