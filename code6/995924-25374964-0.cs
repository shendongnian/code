    string userInput = TextBox1.Text;
    string[] numberArray = userInput.Split(',');
    var list = ListBox1.Items.Cast<string>().
    foreach (string i in numberArray)
    {
        int x = Int32.Parse(i);
        if (x % 2 == 0)
        {
            if (!list.Contains(i)) 
            {
                ListBox1.Items.Add(i);
            }
        }
    }
