    // class scoped variables
           [ThePolyFileType] (pick the right one here :) geometry = null;
    
            void OpenWithDialog()
            {
                var ofd = new OpenFileDialog();
    
                ofd.Filter = "Triangle polygon file|*.poly";
    
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    OpenPolyFile(ofd.FileName);
                }
            }
    
            void OpenPolyFile(string file)
            {
                geometry = TriangleNet.IO.FileReader.ReadPolyFile(file);
                // ...
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (geometry != null)
                {
                  //do your stuff
                }
            }
