    // FileStream file = new FileStream(@"C:\Users\Zeeshan\Downloads\a.txt", FileMode.Open, FileAccess.Read);
    // StreamReader sr = new StreamReader(file);
    // sr.ReadLine();
    // Above three lines are redundant, because you read all of the text inside next line (ReadAllLines)
    var textLines = File.ReadAllLines(@"C:\Users\Zeeshan\Downloads\a.txt");
    // This foreach loop is wrong, since textLines already is array of lines from text file (each element is already single line without Environment.NewLine characters)
    /*foreach (var Line in textLines)
    {
        // (str, "\n\\s*")
        //string[] dataArray = Regex.Split('n');
        string[] dataArray = Line.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        // This CompareTo is redundant also, since you are not using its result
        dataArray[0].CompareTo(comboBox1.SelectedItem);
        if (dataArray[0] == comboBox1.SelectedItem.ToString())
        {
            textBox1.Text = (dataArray[0]);
            textBox2.Text = (dataArray[1]);
            textBox3.Text = (dataArray[2]);
            textBox4.Text = (dataArray[3]);
        }
    }*/
    // Instead of foreachloop above, you just need to put values inside textboxes:
    if (textLines[0] == comboBox1.SelectedItem.ToString())
    {
        textBox1.Text = (textLines[0]);
        textBox2.Text = (textLines[1]);
        textBox3.Text = (textLines[2]);
        textBox4.Text = (textLines[3]);
    }
