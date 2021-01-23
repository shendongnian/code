        private string[] _sentences = {
            "Old height on pictureOne: 766",
            "New height on pictureOne: 900",
            "",
            "Forcing width on objectX"
        };
        private void Form1Paint(object sender, PaintEventArgs e) {
            int y = 10; //Start position
            int x;
            foreach (string s in _sentences) {
                x = 0; //Start position
                foreach (string word in s.Split(' ')) {
                    if (ShouldHeighlightWord(word)) {
                        e.Graphics.DrawString(word + " ", this.Font, new SolidBrush(Color.Red), x, y);
                    }
                    else {
                        e.Graphics.DrawString(word + " ", this.Font, new SolidBrush(Color.Black), x, y);
                    }
                    x += (int)e.Graphics.MeasureString(word + " ", this.Font).Width;
                }
                y += (int)Math.Ceiling(e.Graphics.MeasureString("I", this.Font).Height);
            }
        }
        private bool ShouldHeighlightWord(string word) {
            switch (word) {
                case "on":
                case "Old":
                    return true;
                default:
                    return false;
            }
        }
