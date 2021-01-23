    public void button1_Click(object sender, EventArgs e){
        if(MyClass.WriteToFile(textBox1.Text))
            MessageBox.Show("Succeded, written to file");
        else
            MessageBox.Show("Failer, nothing written to file");
    }
