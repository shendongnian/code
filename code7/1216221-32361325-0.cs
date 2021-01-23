    if (MyHiddenField.Value != "")
     {
        if (Session["c"] == null)
           Session.Add("c", MyHiddenField.Value);
     }
     else if (Session["c"] != null)
       MyHiddenField.Value = Session["c"].ToString();
    
    if(Session["c"] == null)
       Session.Add("c",MyHiddenField.Value);
    else if(MyHiddenField.Value != "")
     {
       MyHiddenField.Value = Session["c"].ToString();
     }
