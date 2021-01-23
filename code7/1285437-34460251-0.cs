    string session_string="";
    SqlConnection cn = new SqlConnection(YOUR_CONNECTION_STRING);
    cn.open();
    SqlCommand cmd = new SqlCommand();
    cmd.Connection=cn;
    cmd.CommandType=CommandType.Text;
    cmd.CommandText="select name_of_pages from permission where username='YOUR_USERNAME'";
    SqlDataReader rdr = cmd.ExecuteReader();
    if(rdr.hasRows==true){
        while(rdr.Read()){
            session_string=rdr["name_of_pages"] + ",";//You need to declare this variable globally before
            session_string=session_string + rdr["name_of_pages"] + ","; //USE THIS LINE , NOT PREVIOUS ONE
        }
    }
        Session["pages"]=session_string;
        //Now to check
        if(Session["pages"].Contains("Index.aspx")){
            //PERFORM SOMETHING POSITIVE
    
        }
        else
        {
            //PERFORM SOMETHING NEGATIVE
        }
    
