    private void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int Group = int.Parse(TxtGroup.Text);
            int Number = int.Parse(TxtNumber.Text);
            Groups.AddNumberToGroup(Number, Group);
            TxtOutput.Text = Groups.GetString();
        }
        catch//(Exception ex)
        {
            //Exception handling here
        }
    }
