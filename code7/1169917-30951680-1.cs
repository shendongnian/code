     private void pictureBoxExt1_Click(object sender, EventArgs e)
            {
                PictureBoxExt pic = sender as PictureBoxExt;
                if (pic != null) {
                    MessageBox.Show("Double Value" +  pic.SomeValue);
                }
                pic.SomeValue = 0.123d;
            }
