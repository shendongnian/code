            int number;
        int locationX;
        int locationY;
        public void CreateRuntimeControl(PictureBox pic)
        {
            Label lbl = new Label();
            number++;
            locationX++;
            locationY = locationY + 100;
            lbl.Name = "lbl" + number.ToString();
            lbl.Size = new System.Drawing.Size(100, 50);
            lbl.Location = new System.Drawing.Point(10 + locationX, 10 + locationY);
            lbl.Text = number.ToString();
            lbl.BackColor = Color.Gray;
            pic.Controls.Add(lbl);
        }
