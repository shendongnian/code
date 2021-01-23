    btnMyButton_Click(object sender, EventArgs e)
    {
          if (((Hashtable)Application["UserOKHashtable"])
                .ContainsKey(Session["UserSessionKey"]))
            {
              // double - clicked or user pressed refresh
              return;
            }
            else
            {
             ((Hashtable)Application["UserOKHashtable"])
              .Add(Session["UserSessionKey"],UserName);
            // your code here
            // and finally
            ((Hashtable)Application["UserOKHashtable"])
             .Remove(Session["UserSessionKey"]);
            }
           }
