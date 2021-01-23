	private void RibbonButtonHandler_Click( object sender, RibbonControlEventArgs e )
	{
		try 
        {
                String tag = null;
				RibbonButton b = (RibbonButton)sender;				
                // Now that you have the button, you know what they wanted.
				tag = b.Tag;
				if ( tag != null )
                {
                }
		}
        catch( Exception )
        { }
	}
