        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 5);
        private void menuItem9_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                using (StreamReader Reader = new StreamReader(openFileDialog1.FileName, true))
                {
                     zee1 = Reader.ReadLine();
                    textBox1.Text = Convert.ToString(zee1);
                    u1 = float.Parse(zee1);
                    zee2 = Reader.ReadLine();
                    textBox2.Text = zee2;
                    v1 = float.Parse(zee2);
                    zee3 = Reader.ReadLine();
                    textBox3.Text = zee3;
                    u2 = float.Parse(zee3);
                    zee4 = Reader.ReadLine();
                    textBox4.Text = zee4;
                    v2 = float.Parse(zee4);
                    Reader.Close();
                    
                   
                    //BackGroundBitmap.Save("result.jpg"); //test if ok
                    pictureBox1.Enabled = true;
                    g = pictureBox1.CreateGraphics();
                    g.DrawLine(pen1, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                  
