    private void Process(object sender, DataReceivedEventArgs e){
	if (richTextBox1.InvokeRequired)
	{
		invoked = true;
		BeginInvoke(new Mensagem(ProcessaMensagem), sender, e);
	}
	else
	{
		try
		{		
			commands.Add(e.Data);
			count++;
			if (count % 5 == 0)
			{
				richTextBox1.Lines = commands.ToArray();
				richTextBox1.SelectionStart = richTextBox1.Text.Length;
				richTextBox1.ScrollToCaret();
				Application.DoEvents();				
			}		
		}
		catch (Exception ex)
		{
			//log logic
		}
	}}
