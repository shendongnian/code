    internal void Draw()
        {
            pb_play.Location = new Point((pb_play.Location.X + X), (pb_play.Location.Y + Y));
        }
        internal void updateInput()
        {
            if (Keyboard.IsKeyDown(Key.Right))
                X = 1;
            else if (Keyboard.IsKeyDown(Key.Left))
                X = -1;
            else
                X = 0;
            if (Keyboard.IsKeyDown(Key.Up))
                Y = -1;
            else if (Keyboard.IsKeyDown(Key.Down))
                Y = 1;
            else
                Y = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            updateInput();
            Draw();
        }
