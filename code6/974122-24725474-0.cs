        RichTextBox output_area;
        CheckBox[] chk;
        Size MatrixSize;
        private void begin_button_Click()
        {
            // Build the child form
            Form check_box = new Form();
            check_box.FormBorderStyle = FormBorderStyle.FixedSingle;
            check_box.StartPosition = FormStartPosition.CenterScreen;
            // Get the values from the textboxes
            int height = Convert.ToInt16("10");
            int width = Convert.ToInt16("7");
            MatrixSize = new Size(width, height);
            // Set the dimensions of the form
            check_box.Width = width * 15 + 40;
            check_box.Height = (height * 15 + 40) * 3;
            // Build checkboxes for the checkbox form
            chk = new CheckBox[height * width];
            int count = 0;
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    chk[count] = new CheckBox();
                    chk[count].Name = count.ToString();
                    chk[count].Width = 15; // because the default is 100px for text
                    chk[count].Height = 15;
                    chk[count].Location = new Point(j * 15, i * 15);
                    check_box.Controls.Add(chk[count]);
                    chk[count].CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);
                    count += 1;
                    //Console.WriteLine(" i: " + i + " j: " + j + " Count: " + count);
                }
            }
            output_area = new RichTextBox();
            output_area.Location = new Point(chk[0].Location.X, chk[count - 1].Location.Y + 30);
            check_box.Controls.Add(output_area);
            output_area.Text = "hello world\n1,1,1,1,1,1,1,1,1\n0,0,0,0,0,1,0,1\nthese ones and zeros are meant to update in real time!";
            output_area.Width = check_box.Width - 40;
            output_area.Height = check_box.Height / 2;
            // Run the form
            check_box.ShowDialog();
        }
        private void CheckBox1_CheckedChanged(Object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            Debug.WriteLine(c.Name);
            StringBuilder sb = new StringBuilder();
            int count = 0;
            for (int i = 1; i <= MatrixSize.Height; i++)
            {
                for (int j = 1; j <= MatrixSize.Width; j++)
                {
                    if (chk[count].Checked)
                    {
                        sb.Append("1,");
                    }
                    else
                    {
                        sb.Append("0,");
                    }
                    count += 1;
                }
                sb.Append("\r\n");
            }
            output_area.Text = sb.ToString(); 
        }
