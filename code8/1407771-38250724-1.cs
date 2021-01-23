    void itemCommandClick(Object sender, FormViewCommandEventArgs e)
      {
        if (e.CommandName == "Update")
        {
            LinkButton button = e.CommandSource as LinkButton;
            //Do rest of the processing 
        }
    }
