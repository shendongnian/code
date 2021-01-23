    private void deleteUser_Click(object sender, EventArgs e)
    {
        try
        {
            DeleteUser(userId: 5);
            MessageBox.Show("User deleted");
        }
        catch(UserNotFoundException ex)
        {
            MessageBox.Show("Cannot delete user");
        }
    }
