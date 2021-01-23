            char padChar = '0';
            for (int i = 002; i <= 033; i++)
            {
                string localFilename = @"\\psf\Home\Pictures\Maulavi\" + i + ".jpg";
                string padStr = i.ToString().PadLeft(3,padChar);
                using (WebClient client = new WebClient())
                {
                    MessageBox.Show(i.ToString());
                    client.DownloadFile("http://eap.bl.uk/EAPDigitalItems/EAP566/EAP566_1_1_19_2-EAP566_Maulvi_January_1946_v43_no2_" + padStr + "_L.jpg", localFilename);
                }
            }
