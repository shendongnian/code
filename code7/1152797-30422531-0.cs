    private void Form1_Load(object sender, EventArgs e)
    {
      int i = 1;
      ExeClass p1 = new ExeClass();
      int j = p1.p1(i); // See that we pass the `i` variable in here and that we catch the return value in the `j` variable.
      Console.WriteLine("Value is now {0}", j); // Will print : "Value is now 2"
    }
   
