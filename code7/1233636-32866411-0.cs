    private void timer1_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < Application.OpenForms.Count; i++)
        {
            Form form = Application.OpenForms[i];
            if (form != this)
            {
                form.Close();
                i--;
            }
        }
    }
