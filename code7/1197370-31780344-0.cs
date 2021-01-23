    private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
        if (e.PageState != null)
        {
            this.text5_input.Text = e.PageState["txtContents"] as string;
			this.RadioButtonInstance.IsChecked = (bool)e.PageState["rbState"];
        }
    }
  
    private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
        e.PageState["txtContents"] = this.text5_input.Text;
		e.PageState["rbState"] = this.RadioButtonInstance.IsChecked;
    }
