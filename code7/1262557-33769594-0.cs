    private void loadLastBtn_Click(object sender, EventArgs e)
    {
        for(int i = 0; i < lstMembers.Count; i++)
        { 
        firstNameTxt.Text = lstMembers[hold].FirstName;
        lastNameTxt.Text = lstMembers[hold].LastName;
        userNameTxt.Text = lstMembers[hold].UserName;
        passwordTxt.Text = lstMembers[hold].Password;
        confPassTxt.Text = lstMembers[hold].ConfPassword;
        majorBox.Text = lstMembers[hold].Major;
        specialtyBox.Text = lstMembers[hold].Specialty;
        }
        hold++;
    }
