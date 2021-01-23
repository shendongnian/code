    using System;
    using System.Text.RegularExpressions;
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (tb_email.Text != "")
        {
            string filter = \w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*; 
           
           Regex regex = new Regex(filter );
	   Match match = regex.Match(tb_email.Text );
	    if (match.Success)
	    {
	         args.IsValid=true;	}
            else
            {
             args.IsValid = false;  
      }	
    }
