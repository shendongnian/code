    protected void Button1_Click(object sender, EventArgs e)
    {
       string name = TextBox1.Text;
       string address = TextBox2.Text;
    
       // Do something with your strings...
       Response.Write("Your name is : " + name + "<br />");
       Response.Write("Your address : " + address);
    }
