    private void button1_Click(object sender, EventArgs e)
    {
        int i = 1;
        int[] p=new int[4];
        p[0] = 25;
        method(ref p);
        string o = p[0].ToString();
    }
    private void method(ref int[] k)
    {
        k[0] = 34;
        k = null; //##
    }
