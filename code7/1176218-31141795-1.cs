    void Application_Error(object sender, EventArgs ex) 
        { 
            Exception e = Server.GetLastError().GetBaseException();
                if (!e.Message.ToUpper().Contains("FILE DOES NOT EXIST."))
                {
    		       //This function is user defined Method which accepts string as inpout and writes it to error.txt file with date and time.
    		       WriteTo_ERROR_TXT_File(e.ToString());                              
    
    		      //Redirect to custom error display page               
                   Server.Transfer("Error.aspx");    
                }        
    
        }
    public void WriteTo_ERROR_TXT_File(string inputString)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.Web.HttpContext.Current.Server.MapPath("Error.txt"), true))
            {
                file.WriteLine(inputString);
            }
    
        }
