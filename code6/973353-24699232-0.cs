        int counter = 1;
        public void draw()
        {
            for (int y = 0; y < screen.GetLength(1); y++)
            {
                for (int x = 0; x < screen.GetLength(0) - 1; x++)
                {
                    screen[x, y] = counter++;
                }
                screen[screen.GetLength(0) - 1, y] = 123;
            }
            if (buffer.Cast<int>().SequenceEqual(screen.Cast<int>()))
            {
                MessageBox.Show("Help!");
                return;
            }
            // check again
            for (int y = 0; y < screen.GetLength(1); y++)
            {
                for (int x = 0; x < screen.GetLength(0) - 1; x++)
                {
                    if (screen[x, y] == buffer[x, y])
                    {
                        MessageBox.Show("Help two!");
                        return;
                    }
                }
            }
