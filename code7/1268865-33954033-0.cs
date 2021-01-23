    class Guard
    {
        public void Draw(Graphics g)
        {
            var state = g.Save();
            try
            {
                // The actual drawing code
            }
            finally
            {
                g.Restore(state);
            }
        }
    }
