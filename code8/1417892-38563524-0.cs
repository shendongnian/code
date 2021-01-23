           if (fileExtension.ToUpper() == ".JPG" || fileExtension.ToUpper() == ".PNG")
            {
                using (Bitmap bitmap = new Bitmap(filename)) // added using statement.
                {
                    //DefaultCompressionJpeg(bitmap);
                    string fn = Path.GetFileNameWithoutExtension(filename);
                    //saadame lisaks ka extensioni, et saaksime lihtsamini faili ümber nimetada
                    VariousQuality(bitmap, fn, fileExtension, fileOriginalDate);
                }
            }
