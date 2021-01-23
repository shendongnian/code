        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Load += delegate(object s2, EventArgs e2)
            {
                f2.Location = new Point(this.Bounds.Location.X + this.Bounds.Width / 2 - f2.Width / 2,
                    this.Bounds.Location.Y + this.Bounds.Height / 2 - f2.Height / 2);
            };
            f2.Show();
        }
