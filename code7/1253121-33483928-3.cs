    public void iniPictureBoxes()
        {
            myPictureBoxes = new List<PictureBox>();
            for (int i = 0; i < 5; i++)
            {
                PictureBox tempPB = new PictureBox();
                tempPB.Location = new Point(i * 15, 10);
                tempPB.Size = new Size(10, 10);
                tempPB.BackColor = Color.Black;
                Controls.Add(tempPB);
                myPictureBoxes.Add(tempPB);
            }
                index = 0;
        }
