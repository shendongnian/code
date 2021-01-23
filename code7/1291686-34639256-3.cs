    void Refresh(object sender, EventArgs e)
		{
			Thread.Sleep(1000);
			n+=1;
			label1.Text = Convert.ToString(n);
		}
		
		public void update()
		{
			Channel.AppendText(irc.readMessage());
		}
		void WORK()
		{
			while(true)
			{
				Channel.Invoke(new MethodInvoker(() => update()));
			}
		}
