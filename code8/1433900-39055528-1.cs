    while (MyReader.Read())
    {
        Console.WriteLine(MyReader[count]);
        count++;
    }
    //This block of code will ALWAYS be executed,
    //no matter the value of count.
    MessageBox.Show("Username and password is correct");
    this.Hide();
    Form2 f2 = new Form2();
    f2.ShowDialog();
    //This IF block is doing nothing.
    if (count == 1)
    {
    }
