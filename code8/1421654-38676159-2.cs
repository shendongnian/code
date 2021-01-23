    public static string GetInput()
    {
        form2 obj_form2 = new form2();
        obj_form2.ShowDialog();
        return obj_form2.textBox.Text;
    }
