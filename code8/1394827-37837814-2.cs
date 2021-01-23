    public void ShowForm2()
    {
        using (Form2 f2 = new Form2())
        {
            if (f2.ShowDialog(this) == DialogResult.OK)
                DoSomethingWith(f2.ValueFromForm3);
        }
    }
