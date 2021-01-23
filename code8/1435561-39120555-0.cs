    public static void LoadProgressIndicator(object parent_control)
    {
     if (parent_control is XtraForm)
    	LoadProgressIndicator(parent_control as XtraForm, null, null, null);
     else
     {
    	if (parent_control is XtraUserControl)
    	   LoadProgressIndicator(null, parent_control as XtraUserControl, null, null);
    	else
    	{
    	   if (parent_control is System.Windows.Forms.Form)
    		  LoadProgressIndicator(null, null, parent_control as System.Windows.Forms.Form, null);
    	   else
    		  LoadProgressIndicator(null, null, null, parent_control as System.Windows.Forms.UserControl);
    	}
     }
    }
