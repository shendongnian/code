    @using (Html.BeginForm("MultipleCommand", "Home", FormMethod.Post, new { id = "submitForm" }))
    {
        .
        .
        .
         <button type="submit" id="btnSave" name="Command" value="create">Save</button>
         <button type="submit" id="btnSubmit" name="Command" value="update">Submit</button> 
    }
    public ActionResult(ComplexModel model, string Command)
    {
        if(Command == "create")
        {
        }
        else if(Command == "update")
        {
        }
        else
        {
            // Default action
        }
    }
