     string[] SName = Request.Form.GetValues("title");
     string[] Email = Request.Form.GetValues("fname");
     int iLength = -1; 
     
     if(SName.Length > Email.Length) 
         iLength = SName.Length;
     else
        iLength = Email.Length;
     for (int i = 0; i < iLength; i++)
     {
         if(i < SName.Length)
            Response.Write(SName[i]);          
         if(i < Email.Length)
            Response.Write(Email[i]);
     }
 
