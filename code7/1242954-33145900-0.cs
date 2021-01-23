    public void Main()
    {
        using LoginForm login = new LoginForm()
        {
            if(login.ShowDialog() != DialogResult.Ok)
            {
                return;
            }
        }
        //Show main form if login was succesfull
        using Form1 main = new Form1()
        {
            main.ShowDialog();
        }
  
    }
