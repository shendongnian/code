    protected void ocultarModalCommand(Object sender, CommandEventArgs e)
    {
        // Identify which ModalPopupExtender should hide
        String extenderId = e.CommandArgument;
        // get the control based on its id
        ModalPopupExtender extender = (MOdalPopupExtender) FindControl("extenderId");
        if (extender != null)
        {
            extender.Hide();
        }
    }
