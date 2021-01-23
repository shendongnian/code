    private void textBox2_Click(object sender, EventArgs e)
    {
        int line = textBox2.GetLineFromCharIndex(textBox1.SelectionStart);
        if (line >= 0 && line < textBox2.Lines.Length) 
            Console.WriteLine(textBox2.Lines[line]);  // or whatever you want to do with it..
    }
