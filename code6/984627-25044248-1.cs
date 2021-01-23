     if (!IsPostBack)
     {
       DataTable subjects = new DataTable();
       using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString)
       {
          SqlDataAdapter adapter = new SqlDataAdapter("SELECT messageId, messageText FROM messages", con);
          adapter.Fill(subjects);
    
          sletBox.DataSource = subjects;
          sletBox.DataTextField = "messageText";
          sletBox.DataValueField = "messageId";
          sletBox.DataBind();
      }
           
        sletBox.Items.Insert(0, new ListItem("Vælg besked", ""));
     }
