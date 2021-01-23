    string output = "Fizz";
    // Loop from 1 to 10 for no reason
    for (int a = 1; a <= 10; a++)
    {
        // Add "Fizz" item to listbox 3 times if 'a' equals 3
        if (a == 3)
        {
            for (int b = 1; b <= 3; b++)
            {
                listBox1.Items.Add(output);
            }
            // Multiply number of items in listBox with 3 for no reason and display it in textbox
            textBox1.Text = (listBox1.Items.Count * 3).ToString();
        }
    }
