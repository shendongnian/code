    if(!textBox2.All(char.IsDigit)
    {
        DialogResult dialogResult = MessageBox.Show("Delete all non-digits?", "Warning", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            textBox2.Text = string.Concat(textBox2.Text.Where(char.IsDigit));
        }
        else if (dialogResult == DialogResult.No)
        {
            textBox2.Text = "Error! You can't sum non-digits!";
        }
    }
    
