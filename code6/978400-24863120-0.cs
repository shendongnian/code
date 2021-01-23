         private string _displayString;
         public string DisplayString 
        {
            get { return HttpUtility.HtmlEncode(_displayString); }
            
        }
