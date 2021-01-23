    string[] lines = System.IO.File.ReadAllLines("example.txt");
    foreach(string line in lines)
    {
        richTextBox1.Text += line+"\n";
    }
