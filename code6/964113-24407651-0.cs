    public void matchimage(System.Drawing.Bitmap img1, System.Drawing.Bitmap img2)
        {
            string img1_ref, img2_ref;
            int count1 = 0, count2 = 0;
            bool flag = true;
    
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            count2++;
                            flag = false;
                            break;
                        }
                        count1++;
                    }
                    
                }
                if (flag == false)
                    MessageBox.Show("Sorry, Images are not same , " + count2 + " wrong pixels found");
                else
                    MessageBox.Show(" Images are same , " + count1 + " same pixels found and " + count2 + " wrong pixels found");
            }
            else
                MessageBox.Show("can not compare this images");
    
            img1.Dispose();
            img2.Dispose();
        }
