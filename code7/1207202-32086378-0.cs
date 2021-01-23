        [STAThread]
        static void Main()
        {
            var form = new Form1();
            if (form.ShowDialog() == DialogResult.OK)
            {
                using (var game = new Game1())
                    game.Run();
            }
        }
