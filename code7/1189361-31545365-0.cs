      using(Form1 form = new Form1())
      {
          if(form.ShowDialog() == DialogResult.OK)
          {
              using (Game1 game = new Game1())
              {
                  game.Run();
              }
          }
      }
