    if (Session["user_id"] == null)
    {
        // session not exists
    }
    else
    {
        long user_id;
        if(!long.TryParse(Session["user_id"].ToString(), out user_id))
        {
           // Handle sitiation if it is not possible to cast
        }
    }
