    private void YourMethod()
    {
    	if (richEditControl1.InvokeRequired)
    	{
    		richEditControl1.Invoke((MethodInvoker)delegate
    		{
    			YourMethod(sender, e);
    		});
    	}
    	else
    	{
    		linkRange = richEditControl1.Document.AppendText(split[i] + "\n\n");
            hyperlink = richEditControl1.Document.CreateHyperlink(linkRange);
    	}
    }
