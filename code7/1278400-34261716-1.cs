    // must be initialized somewhere in constructors
    private readonly ReusableFormContainer<FormA> container_A;
    private readonly ReusableFormContainer<FormB> container_B;
    private void button1_Click(object sender, EventArgs e)
    {
        container_A.Show();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        container_B.Show();
    }
