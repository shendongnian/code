    using (GameConnection db = new GameConnection())
    {
    
        Game newGame = new Game();
        int GameID = 0;
        if (Request.QueryString.Count > 0)
        {
            GameID = Convert.ToInt32(Request.QueryString["gameID"]);
            newGame = (from game in db.Games
                        where game.gameID == GameID
                        select game).FirstOrDefault();
        }
        newGame.teamA = teamATextBox.Text;
        newGame.teamB = teamBTextBox.Text;
    
        if (GameID == 0)
        {
            db.Games.Add(newGame);
        }
        try
        {
            db.SaveChanges();
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var ve in eve.ValidationErrors)
            {
                Console.WriteLine(ve.PropertyName + " " + ve.ErrorMessage);
            }
        }
        Response.Redirect("~/Default.aspx");
    }
