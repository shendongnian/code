    Using System.Diagnostics;
    int count;
    private void Form1_Load(object sender, EventArgs e)
    {
        Random num = new Random();
        count = num.Next(1, 101); // remove your break point on this line
        Debug.WriteLine(count); // put your break point here
    }
