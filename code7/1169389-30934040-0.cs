            var centers =
                System.Windows.Forms.Screen.AllScreens.Select(
                    s =>
                        new
                        {
                            Left = s.Bounds.X + (s.WorkingArea.Right - s.WorkingArea.Left)/2,
                            Top = s.Bounds.Y + (s.WorkingArea.Bottom - s.WorkingArea.Top)/2
                        });
            foreach (var c in centers)
            {
                var w = new Window1();
                w.Left = c.Left - w.Width/2;
                w.Top = c.Top - w.Height/2;
                w.Show();
            }
