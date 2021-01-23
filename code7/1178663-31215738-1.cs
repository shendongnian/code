    Profile profile = new Profile() ;
    profile.SetPropertyValue("hair","color","brown") ;        
    
    internal class Profile()
    {
      private Hair hair_ = new Hair();   
      private Job  job_  = new Job ();
       
      internal Hair hair { get { return hair_ ; } } 
      internal Job  job  { get { return job_  ; } } 
    
      private void SetPropertyValue(string profileItemName, string ItemPropertyName, string value)
      { // it is assumed that the different items (hair or job) of the Profile are accessible 
        // with a a property
 
        // first find the Item object, i.e. hair or job                  
        object itemObj = this.GetType().GetProperty(profileItemName).GetValue(this,null);
        // assign to Item property the input value, e.g. hair.color=Brown
        itemObj.GetType().GetProperty(ItemPropertyName).SetValue(itemObj, value, null);
       }
     }
    
    internal class Hair()
    {
      private string color_ ;   
      private string style_ ;
       
      internal string   color { get { return color_  ; } set {color_ = value ; } } 
      internal string   style { get { return style_  ; } set {style_ = value ; } } 
     }
 
