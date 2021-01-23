    // I'll walk you though your code...
    private void button1_Click(object sender, EventArgs e)
    {
        /* this is not needed
        FileStream file = new FileStream(@"C:\Users\Zeeshan\Downloads\a.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(file);
        sr.ReadLine();
        */
        // this returns an array of all of the lines you have in your text file 
        //   each line is a new element in the array
        var textLines = File.ReadAllLines(@"C:\Users\Zeeshan\Downloads\a.txt");
    
        // here you try to loop the lines in the text file.
        foreach (var Line in textLines)
        {
            // (str, "\n\\s*")
            //string[] dataArray = Regex.Split('n');
            // here you try to split the line on a new line CR + LF (which doesn't exist) so dataArray only has one element
            string[] dataArray = Line.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            // this line is useless
            dataArray[0].CompareTo(comboBox1.SelectedItem);
            // this will be true if the current line is the same value as your drop down.
            if (dataArray[0] == comboBox1.SelectedItem.ToString())
            {
                // this line will work
                textBox1.Text = (dataArray[0]);
                // these will always fail.
                textBox2.Text = (dataArray[1]);
                textBox3.Text = (dataArray[2]);
                textBox4.Text = (dataArray[3]);
            }
        }
    }
