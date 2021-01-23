    public void Atextbox_TextChanged(object sender, EventArgs e)
    {
       int value;
       if (int.TryParse(Atextbox.Text, out value))
       {
           Btextbox.Text = (100 - value).ToString();
       }
    }
