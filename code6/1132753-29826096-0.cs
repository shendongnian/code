    var strings = new List<string>() 
    {
        textBoxLectura1.Text;
        textBoxLectura2.Text;
        textBoxLectura3.Text;
    }
    var output = string.Join('\n',strings.Where(s => !string.IsNullOrEmpty(s));
    if (!string.IsNullOrEmpty(output)) 
    {
        Console.Writeline(output);
    }
    else
    {
        MessageBox.Show("no entrys");
    }
