    string[] SName = Request.Form.GetValues("title");
    string[] Email = Request.Form.GetValues("fname");
    for (int i = 0; i < SName.Length; i++)        
       Response.Write(SName[i]);       
    for (int i = 0; i < Email.Length; i++)
       Response.Write(Email[i]);
        
