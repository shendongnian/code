    private void displayAll_Click(object sender, EventArgs e)
    {
        richTextBox1.Clear();
        for (int i = 0; i < ClassList.Count; i++)
        {
            richTextBox1.Text += ("Student: " + Convert.ToString(i) +
                             "\nName: " + ClassList[i].Name +
                            "\nSurname: " + ClassList[i].Surname +
                             "\nAge: " + ClassList[i].Age +
                             "\nStudent Average: " + Convert.ToString(ClassList[i].AverageMark));
        }
        //Displaying all the students
        MessageBox.Show("Display all students.");
    }
