    private void btnSubmit_Click(object sender, EventArgs e){
    string path = "C:\\Users\\Mytext.txt";
    if (!File.Exists(path))
    {
        File.Create(path).close();
        TextWriter tw = new StreamWriter(path);
        tw.WriteLine("The very first line!");
        tw.Close();
    }
    else if (File.Exists(path))
    {
        TextWriter tw = new StreamWriter(path);
        tw.WriteLine("The next line!");
        tw.Close();
    }}
