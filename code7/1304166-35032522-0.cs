    public void SetText(params Control[] controls, string text)
    {
        foreach(var ctrl in controls)
		{
			ctrl.Text = text;
		}
	}
	
