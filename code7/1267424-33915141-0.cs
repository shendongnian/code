    Control []controls=this.Controls.Find("pictureBox" + resultValue.ToString(), true);
            if (controls != null && controls.Length > 0)
            {
                foreach (Control control in controls)
                {
                    if (control.GetType() == typeof(PictureBox))
                    {
                        PictureBox pictureBox = control as PictureBox;
                        pictureBox.BackColor = Color.FromArgb(r, g, b);
                    }
                }
            }
