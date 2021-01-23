    PictureBox pictureBox1 = new PictureBox { Name = "pictureBox1" };
    PictureBox pictureBox2 = new PictureBox { Name = "pictureBox2" };
    PictureBox pictureBox3 = new PictureBox { Name = "pictureBox3" };
    PictureBox pictureBox4 = new PictureBox { Name = "pictureBox4" };
    PictureBox pictureBox5 = new PictureBox { Name = "pictureBox5" };
    Controls.Add(pictureBox1);
    Controls.Add(pictureBox2);
    Controls.Add(pictureBox3);
    Controls.Add(pictureBox4);
    Controls.Add(pictureBox5);
    foreach (var control in Controls.Cast<Control>().Where(control => control is PictureBox))
    {
         control.Click += (sender, args) =>
         {
              switch (control.Name)
              {
                   case "pictureBox1":
                       MessageBox.Show("Its me " + control.Name);
                       break;
                   case "pictureBox2":
                       MessageBox.Show("Its me " + control.Name);
                       break;
                   ...
              }
         };
    }
