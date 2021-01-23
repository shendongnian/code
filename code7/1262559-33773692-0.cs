    // -1 Indicates that you should start at the end of the list
    int index = -1; 
    private void loadButton_Click(object sender, EventArgs e)
    {
        if (members != null && members.Count > 0) // Avoid accessing if list is empty or null
        {
            if (index == -1)
                index = members.Count - 1;
            firstNameTxt.Text = lstMembers[index].FirstName;
            lastNameTxt.Text = lstMembers[index].LastName;
            userNameTxt.Text = lstMembers[index].UserName;
            passwordTxt.Text = lstMembers[index].Password;
            confPassTxt.Text = lstMembers[index].ConfPassword;
            majorBox.Text = lstMembers[index].Major;
            specialtyBox.Text = lstMembers[index].Specialty;
            if (index == 0) // Reached beginning of array
                index = -1; // Indicate that next time the last element must be accessed
            else
                --index;
        }
    }
