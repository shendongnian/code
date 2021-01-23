    public string[] get()
    {
        string[] arr = new string[listBox1.Items.Count];
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            arr[i] = listBox1.Items[i].ToString();
        }
        return arr;
    }
