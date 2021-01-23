            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    // where pData is your byte array
                    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    Image originalImage = Image.FromStream(mStream);
                    picBox.Image = originalImage;
                }
            }
            catch (Exception ex)
            {
            }
