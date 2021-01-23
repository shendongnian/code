        public Map(int rows, int columns, Form1 owner)
        {
            int x = 40, y = 40;
            // Create map
            for (int row = 0; row < rows; row++)
            {
                List<Hex> r = new List<Hex>();
                for (int column = 0; column < columns; column++)
                {
                    Hex h = new Hex(null)
                    {
                        Location = new System.Drawing.Point(x, y),
                    };
                    r.Add(h);
                    x += 40;
                }
                Grid.Add(r);
                x -= columns * 40;
                x = (row % 2) * 20 + 20;
                y += 30;
            }
        }
        public void DrawHexes(Form1 owner)
        {
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            BufferedGraphics buf = context.Allocate(owner.CreateGraphics(), owner.ClientRectangle);
            buf.Graphics.Clear(Color.Red);
            foreach (List<Hex> row in Grid)
            {
                foreach (Hex h in row) h.DrawMe(buf.Graphics);
            }
            buf.Render();
        }
