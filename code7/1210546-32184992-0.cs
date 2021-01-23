    byte[] imagedata = (byte [])dataGridView1[4, dataGridView1.SelectedRows[0].Index].Value;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imagedata, 0, imagedata.Length))
                {
                    ms.Write(imagedata, 0, imagedata.Length);
                    //Set image variable value using memory stream.
                    image = Image.FromStream(ms, true );
                }
