    var button = (Control)sender;  // sender is the button
    // then ask the button's parent control to find the textbox
    var txtSubjectNotes = button.Parent.FindControl("txtSubjectNotes") as RadTextBox; 
    if(txtSubjectNotes != null) 
    {
        // make sure it's not null
        _note.subject = txtSubjectNotes.Text;
    }
