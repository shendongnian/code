    Label dynamiclabel1 = new Label();
    dynamiclabel1.Location = new Point(280, 90);
    dynamiclabel1.Name = "lblid";
    dynamiclabel1.Size = new Size(150, 100);
    dynamiclabel1.Text = "Smith had omitted the paragraph in question (an omission which had escaped notice for twenty years) on the ground that it was unnecessary and misplaced; but Magee suspected him of having been influenced by deeper reasons.";
            
    dynamiclabel1.Font = new Font("Arial", 10, FontStyle.Regular);
    int lines = 3; //number of lines you want your text to display in
    using (Graphics g = CreateGraphics())
    {
         SizeF size = g.MeasureString(dynamiclabel1.Text, dynamiclabel1.Font);
         float w=size.Width / lines;
         dynamiclabel1.Height = (int)Math.Ceiling(size.Height*lines);
         dynamiclabel1.Width = (int)Math.Ceiling(w);
    }
    panel1.Controls.Add(dynamiclabel1);
