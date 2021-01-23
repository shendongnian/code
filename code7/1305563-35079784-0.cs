    private void button1_Click(object sender, EventArgs e)
        {
            int s = 4;
            int x = 0;
            int y = 0;
            for (int i = 0; i < s; i++)
            {
                if (i == 0)
                {
                    x = 38;
                    y = 60;
                }
                else
                {
                    y += 50;
                }
                PictureBox dynamicPicture1 = new PictureBox();
                dynamicPicture1.Tag = i;
                dynamicPicture1.Location = new Point(x, y);
                dynamicPicture1.Name = "pictureBox" + i;
                dynamicPicture1.Size = new System.Drawing.Size(30, 27);
                dynamicPicture1.ImageLocation = @"C:\Users\nxa00960\Downloads\abc.jpg";
                panel1.Controls.Add(dynamicPicture1);
                dynamicPicture1.Click += dynamicPicture1_Click;
            }
        }
        void dynamicPicture1_Click(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            switch (pictureBox.Name)
            {
                case "pictureBox0":
                    //do something
                    break;
                case "pictureBox1":
                    //do something
                    break;
                case "pictureBox2":
                    //do something
                    break;
                case "pictureBox3":
                    //do something
                    break;
                default:
                    break;
            }
        }
