    public Form1()
    {
        InitializeComponent();
        img0 = Image.FromFile("d:\\eye1.jpg");
    }
    Image img0 = null;
    private void button1_Click(object sender, EventArgs e)
    {
        PropertyItem propItem = img0.PropertyItems[0];
        using (var file = Image.FromFile("D:\\xyzXXX.jpg"))
        {
            propItem.Id = 0x9286;  // this is called 'UserComment'
            propItem.Type = 2;
            propItem.Value = System.Text.Encoding.UTF8.GetBytes(textBox1.Text + "\0");
            propItem.Len = propItem.Value.Length;
            file.SetPropertyItem(propItem);
            // now let's see if it is there: 
            PropertyItem propItem1 = file.PropertyItems[file.PropertyItems.Count()-1];
            file.Save(newFileName);
        }
    }
