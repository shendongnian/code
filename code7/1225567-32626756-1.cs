    Hide();
    string taskName1 = textBox1.Text;
    string DateTime1 = textBox2.Text;
    string More1 = textBox3.Text;
    Form1 celender = new Form1(taskName1,DateTime1,More1,true);         
    celender.Show();
    celender.Closed += (s, args) => this.Close();
