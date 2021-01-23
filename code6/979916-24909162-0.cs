    private string yourItem; // assuming we are just dealing with strings...
    public String YourItem {
       get { return yourItem; }
       set {
              if( String.Equals(yourItem, value, StringComparison.OrdinalIgnoreCase) )
                 return;
   
              OnYourItemChanged(); // Do your logics here
              RaisePropertyChanged("YourItem");
            }
       }
       
       private void OnYourItemChanged()
       {
           // .. do stuff here 
       }
