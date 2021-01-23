    private void SelfAdd(TextBox textBox, Label label)
    {
        try
        {
            label.Text = (Convert.ToInt32(textBox.Text) + Convert.ToInt32(label.Text)).ToString();
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }
