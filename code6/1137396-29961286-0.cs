     set
        {
           ViewState["TransactionData"] = value;
           gridview.DataSource = value as List<TransactionEntity>; //check if null etc 
           gridview.DataBind();// ...               
        }
