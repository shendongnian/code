                foreach (DataRow row in t.Rows)
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(row["Poster"].ToString());
                    myRequest.Method = "GET";
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    Image img = Bitmap.FromStream(myResponse.GetResponseStream());
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img, 30, 10);
                    myResponse.Close();
                    row["Img"] = bmp;
                }
