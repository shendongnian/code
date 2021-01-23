    int deleteQuestion;
    if(!Int32.TryParse(textBox6.Text, out deleteQuestion))
    {
        MessageBox.Show("Not a valid number to delete a question!");
        return;
    }
    int addQuestion;
    if(!Int32.TryParse(textBox7.Text, out addQuestion))
    {
        MessageBox.Show("Not a valid number to add a question!");
        return;
    }
