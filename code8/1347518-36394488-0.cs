    string path;
    private void button1_Click(object sender, EventArgs e)
    {
        // Create a file in isolated storage.
        IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
        IsolatedStorageFileStream stream = new IsolatedStorageFileStream("test.txt", FileMode.Create, store);
        StreamWriter writer = new StreamWriter(stream);
        writer.WriteLine("Hello");
        writer.Close();
        stream.Close();
        // Retrieve the actual path of the file using reflection.
        path = stream.GetType().GetField("m_FullPath", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stream).ToString();
        MessageBox.Show("Created File:" + path);
    }
    private void button3_Click(object sender, EventArgs e)
    {
        // Hardcoded? Yech, You should store this info somewhere
        path = @"C:\Users\xxxxxx\AppData\Local\IsolatedStorage\xzzzo1dc.wni\4xhaqngq.5jl\Url.snvxh15wown3vm2muv25oq55wafnfhxw\AssemFiles\test.txt";
    }
    private void button2_Click(object sender, EventArgs e)
    {
        String Text = File.ReadAllText(path);
        MessageBox.Show("read storage: " + Text);
    }
