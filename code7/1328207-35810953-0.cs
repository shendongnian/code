    Check Role Using session and provide condition like this
        string Role="";
        
        on Login button click event check the role
    
       YourLoginMethod()
       {
          // Your Login Code and after check
         //Pass Role in string above or Use session
         if(Role=="admin")
         {
         Response.Redirect("~/Admin.aspx");
        }
        else{
         Response.Redirect("~/Index.aspx");
        }
       }
    
        
