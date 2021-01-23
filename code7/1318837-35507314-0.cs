    private void grdReport_RowCommand(object sender, CommandEventArgs e)
    {
        string commandName = e.CommandName;
        string commandArg = e.CommandArgument.ToString();
        switch (commandName)
        {
            case ("Ref"):
                //do whatever for Ref
                break;
            case ("Subject"):
                //whatever for Subject
                break;
            default:
                throw new NotImplementedException();
                break;
        }
    }
