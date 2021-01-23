        [STAThread]
        static void Main(string[] args)
        {
            if (args[0] == "startFromWinForms")
            {
                using (var game = new Game1())
                    game.Run();
            }
        }
