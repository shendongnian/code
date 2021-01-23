    protected void rptdata_ItemCommand(object source, RepeaterCommandEventArgs e)
     {   
       //logic for deleteing
    	switch (e.CommandName)
                {
                    case "edit":
                        MyEditFunction(e.CommandArgument.ToString());
                        break;
                    case "delete":
                        MyDeleteFunction(Convert.ToInt32(e.CommandArgument));
                        break;
                }
     }
