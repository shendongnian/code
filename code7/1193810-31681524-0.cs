    public void btnPreOpChecklist_Click(object sender, EventArgs e)
    {
        //create secondary form for pre-anaesthetic checklist
        PreAnaestheticChecklist checklistForm = new PreAnaestheticChecklist();
        //load pre-anaesthetic checklist form to screen
        checklistForm.Show(this); // <-- passing in the Owner
    }
