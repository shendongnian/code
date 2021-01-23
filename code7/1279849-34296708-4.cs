    private void button1_Click(object sender, EventArgs e)
    {
        Students student = new Students();
        student.Name = textBox4.Text;
        student.Surname = textBox5.Text;
        student.Age = Convert.ToInt32(textBox6.Text);
        listBox1.Items.Add(student);         
    }
