    private void button1_Click(object sender, EventArgs e)
    {
        string a = "xx";
        string b = "xx";
        string c = "x";
        string d = String.Intern(c + c);
        Console.WriteLine((object)a == (object)b); // True
        Console.WriteLine((object)a == (object)d); // True
    }
    private void button2_Click(object sender, EventArgs e)
    {
        string a = textBox1.Text; //type in xx at runtime
        string b = textBox2.Text; //type in xx at runtime
        string c = textBox3.Text; //type in just "x" at runtime
        string d = String.Intern(c + c);
        Console.WriteLine((object)a == (object)b); // False with runtime values that have the same value
        Console.WriteLine((object)a == (object)d); // False 
        Console.WriteLine(a == d); // True - the Equals Operator of the string works as expected still 
    }
