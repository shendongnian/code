        private void CreateCheckBox(){
            CheckBox cb = new CheckBox();
            cb.Location = new Point(10, 10);
            cb.Width = 150;
            Controls.Add(cb);
            cb.Text = "This is a long text that needs to be broken down into multiple lines.";
            cb.Height = GetHeight(cb);
        }
        private static int GetHeight(CheckBox cb) {
            using (Graphics g = cb.CreateGraphics()) {
                var size = g.MeasureString(cb.Text, cb.Font);
                int rows = (int)Math.Ceiling(((double) size.Width/cb.Width));
                return (int)(rows*size.Height);
            }
        }
