    bool Check()
    {
        if (textBox1.Text.All(char.IsDigit))
        {
            return true;
        }
        else
        {
            MessageBox.Show("The data you entered is incorrect","Error",MessageBoxButtons.OK);
            return false;
        }
    }
