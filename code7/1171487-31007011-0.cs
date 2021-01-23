        private Dictionary<string, Rectangle> pRecs = new Dictionary<string, Rectangle>();
        private void button1_Click(object sender, EventArgs e)
        {
            List<Rectangle> particles = new List<Rectangle>();
            // ... assuming there are some values in "particles" ...
            for (int i = 0; i < particles.Count; i++ )
            {
                // you can't have duplicate keys, make sure "pRecs" is empty if you are re-using it!
                pRecs.Add("r" + i.ToString(), new Rectangle(10, 10, 10, 10));
            }
        }
        private void Foo()
        {
            // ... access one of the rectangles "by name" from somewhere else ...
            Rectangle tmp = pRecs["r2"];
        }
