    int[] array = new int[] { 10, 20, 30, 40 };
    private void Form1_Load(object sender, EventArgs e)
    {
        this.numericUpDown1.DataBindings.Add("Value", array, "");
        ((BindingManagerBase)this.numericUpDown1.BindingContext[array]).Position = 2;
    }
