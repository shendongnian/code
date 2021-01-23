    public Visiblity IsAuthorized
    {
       get { return (Role == "Admin" && OtherProp == "True") ? Visbility.Visible : Visibility.Hidden; }
    
    }
     // When a value changes in Role or OtherProp fire PropertyChanged for IsAuthorized. 
    public string Role
    {
       get { return_Role;}
       set { _Role = value; 
             PropertyChanged("Role");
             PropertyChanged("IsAuthorized");
           }
    }
    
    public string OtherProp
    {
       get { return_OtherProp;}
       set { _OtherProp = value; 
             PropertyChanged("OtherProp");
             PropertyChanged("IsAuthorized");
           }
    }
