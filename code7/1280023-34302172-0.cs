    public void DodajSLIKU(Image slika, PictureBox[] t)
            {
                foreach (var item in t)
                {
                    if (item != null)
                    {
                        if (item.Image == null)  
                            item.Image = slika;
                    }
                }            
            }
