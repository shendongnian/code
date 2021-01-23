    foreach (RadioButton rBtn in this.Controls.OfType<RadioButton>())
    {
    	if(rBtn.Checked)
    	{
            label2.Text = "Installation location:'" + rBtn.Text;
            break;
    	}
    }
