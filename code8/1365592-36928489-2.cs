    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var boundList = (IList<PersonEntry>)listBox1.DataSource;
        PersonEntry selected = boundList[listBox1.SelectedIndex];
        Label label1 = new Label();
        label1.Size = new Size(270, 75);
        label1.Location = new Point(10, 10);
    
        label1.Text += "Name: " + selected.Name + "\n" +
                               "Email: " + selected.Email + "\n" +
                               "Phone number: " + selected.PhoneNum;
       
        myPerInfoForm.Controls.Add(label1);
        myPerInfoForm.ShowDialog();
    
    }
