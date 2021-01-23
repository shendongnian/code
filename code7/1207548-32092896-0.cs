    public static string Show(string caption = "Enter data")
    {
    	Application.Current.Dispatcher.Invoke(new Action(() =>
    	{
    		CustomMessageBox cmb = new CustomMessageBox();
    		cmb.txt_block.Text = caption;
    		cmb.ShowDialog();
    	}));
    	return cmb.Value;
    }
