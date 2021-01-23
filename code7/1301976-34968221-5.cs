    private void Form1_Load(object sender, EventArgs e)
    {
        InfoBox aBox = new InfoBox();
        aBox.TextBox1.Text = "<Comment>";
        aBox.LoadImage("D:\\stop32.png");  // some image file
        aBox.Button1Click = myButton1Action;
        flowLayoutPanel1.Controls.Add(aBox);
    }
    void myButton1Action (InfoBox box)
    {
        Console.WriteLine(box.Label2Text);
    }
