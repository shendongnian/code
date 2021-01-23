    struct TestStruct
    {
        public int Value;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        TestStruct lOriginal = new TestStruct();
        lOriginal.Value = 42;
        dynamic n = lOriginal;
        dynamic m = n;
        lOriginal.Value = "4711"
        MessageBox.Show(m.Value.ToString());
        n.Value = 4711;
        MessageBox.Show(m.Value.ToString());
    }
