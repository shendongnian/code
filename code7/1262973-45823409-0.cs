      private void listImage_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                try
                {
                    pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); 
                    pictureBox1.Refresh();
                    btnGuardarFoto.Visible = true;                
                }
                catch (Exception ex)
                {
                    oCOM.MsgError("Error en listImage_MouseDoubleClick() " + ex.Message);
                }
            }
