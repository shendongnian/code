    bool passed = false;
    string s = String.Empty;
    DateTime dt;
    try{
         s = input; //Whatever you are getting the time from
         dt = Convert.ToDateTime(s); 
         s = dt.ToString("HH:mm"); //if you want 12 hour time  ToString("hh:mm")
         passed = true;
    }
    catch(Exception ex)
    {
    
    }
