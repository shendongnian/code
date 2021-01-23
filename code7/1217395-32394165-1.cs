    private void Button_Click(object sender, EventArgs e)
    {
        if (Form1.Instance != null) //must be careful about this.
        {
            Form1.Instance.LoadTable(); //like this you will call the method on the existing instance of the form.
        }
    }
