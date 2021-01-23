    Form form = new SignIn();
    if (form.ShowDialog() == DialogResult.OK)
    {
        if (form.UserName =="Developer" && form.Password == "poxus17")
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
