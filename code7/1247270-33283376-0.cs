    private void Form1_Load(object sender, EventArgs e)
    {
        RefreshListView();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Form2 pop = new Form2();
        pop.ShowDialog();
        string name = pop.name;
        int age = int.Parse(pop.Age);
        string dob = pop.DateOfBirth;
        string addr = pop.Address;
                        StreamWriter write = new StreamWriter(@"C:\Users\Admin\Desktop\myfile\customers.txt",true);
                        write.Write("--\n");
                        write.Write("{0}\n",name);
                        write.Write("{0}\n",dob);
                        write.Write("{0}\n",age);
                        write.Write("{0}\n",addr);
                        write.Close();
         RefreshListView();
    }
    private void RefreshListView()
    {
        listView1.Items.Clear();
        RichTextBox rtb = new RichTextBox();
        rtb.Text = File.ReadAllText(@"C:\Users\Admin\Desktop\myfile\customers.txt");
        int i = 0;
        foreach (string line in rtb.Lines)
        {
            if (line == "--")
            {
                ListViewItem item = new ListViewItem();
                item.Text = rtb.Lines[i + 1];
                item.SubItems.Add(rtb.Lines[i + 2]);
                item.SubItems.Add(rtb.Lines[i + 3]);
                item.SubItems.Add(rtb.Lines[i + 4]);
                listView1.Items.Add(item);
            }
            i += 1;
        }
    }
