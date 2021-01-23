	private void ShowHideToggle_CheckStateChanged(object sender, EventArgs e)
	{
		t.Tick += delegate
		{
			if (Checked)
			{
				if (this.Width > 30)
					this.Width -= ;
				else
					t.Stop();
			}
			else
			{
				if (this.Width < 300)
					this.Width -= 2;
				else
					t.Stop();
			}
		};
        t.Start();
    }
			
			t.Start();
		}
