    bool exists = false;
    for(int i = 0; i < ow_terminal.Count; i++)
    {
        if(ddlterminal.SelectedValue.Contains(ow_terminal[i])
           && ddlDeparture.SelectedValue.Contains(ow_depart[i])
           && ddlOrigin.SelectedValue.Contains(ow_origin[i])
           && ddlDestination.SelectedValue.Contains(ow_destination[i]))
         {
               exists = true;
               break;
         }
    }
    if(exists) lblMessage.Text = "Record exist"; 
    else lblMessage.Text = "No record exist";
