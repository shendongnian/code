    private void button1_Click(object sender, EventArgs e)
    {
       var form2 = new Form2();
       button1.Visible = false;
       form2.FormClosed += (s,ev) => button1.Visible = true;
       form2.Show();
    }
