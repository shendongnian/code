            DataTable dt = new DataTable();
            dt = tt.GetImage(Ids);
            foreach (DataRow row in dt.Rows)
            {
                byte[] img1 = (byte[])row["Im1"];
                string base1 = Convert.ToBase64String(img1);
                Image1.ImageUrl = "data:image/jpg;base64," + img1;
                Image1.Visible = (!string.IsNullOrEmpty(base1));
                byte[] img2 = (byte[])row["Im2"];
                string base2 = Convert.ToBase64String(img2);
                Image2.ImageUrl = "data:image/jpg;base64," + base2;
                Image2.Visible = (!string.IsNullOrEmpty(base2));
                byte[] img3 = (byte[])row["Im3"];
                string base3 = Convert.ToBase64String(img3);
                Image3.ImageUrl = "data:image/jpg;base64," + base3;
                Image3.Visible = (!string.IsNullOrEmpty(base3));
                byte[] img4 = (byte[])row["Im4"];
                string base4 = Convert.ToBase64String(img4);
                Image4.ImageUrl = "data:image/jpg;base64," + base4;
                Image4.Visible = (!string.IsNullOrEmpty(base4));
                byte[] img5 = (byte[])row["Im5"];
                string base5 = Convert.ToBase64String(img5);
                Image5.ImageUrl = "data:image/jpg;base64," + base5;
                Image5.Visible = (!string.IsNullOrEmpty(base5));
            }
