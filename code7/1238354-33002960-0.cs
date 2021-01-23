    Session_Start() //event
    {
         var cn = new Class_Name();
         cn.Start(string val1,string val2);
         Session["class_name"] = cn;
    }
    Session_end()
    {
        var cn = Session["class_name"] as Class_Name;
        if (cn !=null) 
        {
             cn.Emnd();
        }
    }
