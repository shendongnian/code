    PictureBox[] p = new PictureBox[10];
                for (int i = 0; i < 10; i++)
                {
                    p[i] = new PictureBox();
                    p[i].ImageLocation = "location";
                    p[i].Location = new Point(0,0);
                    p[i].Size = new Size(50, 50);
                    this.Controls.Add(p[i]);
                }
