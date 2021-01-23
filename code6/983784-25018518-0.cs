    // this function should be written in the main form
    private void btnTaskAdd_Click(object sender, EventArgs e)
    {
        var form=new addTaskForm();
        if(form.ShowDialog()==DialogResult.Ok)
        {
             // in the form addTaskForm you add a string property called SelectedItem, 
             // and on selection change in the lstAddTask then you set the SelectedItem, 
             // the lstAddTask_SelectedIndexChanged will be written in addTaskForm
             lstMain.Items.Add(form.SelectedItem);
             this.Close();
        }
    }
