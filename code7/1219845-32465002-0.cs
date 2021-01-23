    string filename="yourfile path";
    string value="your value"
    var items = System.IO.File.ReadAllText(filename).Split(' ');
    if (items.Contains(value))
        this.Button1.Enabled = false;
    else
        System.IO.File.AppendAllLines(filename, new string(){value} );
