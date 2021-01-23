                byte[] fileData = null;
                using (var fs = new FileStream("C:\\1\\roses.jpg", FileMode.Open, FileAccess.Read))
                    {
                    var totalLength = (int)fs.Length;
                    using (var binaryReader = new BinaryReader(fs))
                        {
                        fileData = new byte[totalLength];
                        fs.Read(fileData, 0, totalLength);
                        fs.Close();
                        }
                    MemoryStream ms = new MemoryStream(fileData);
                    pictureBox1.Image = Image.FromStream(ms);
                    }
