    private void btnDelete_Click(object sender, EventArgs e)
     {
            try
            {
                var old = myPictureBox.Image;
                myPictureBox.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\Images\defaultImage.jpg");
                old.Dispose();
                System.IO.File.Delete(txtFileName.Text);
                MessageBox.Show("File Delete Sucessfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
     }
