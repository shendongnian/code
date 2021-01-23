            files.Clear();
            imageList1.Images.Clear();
            listView1.Clear();
            string[] part1 = null, part2 = null, part3 = null;
            part1 = Directory.GetFiles(p, "*.jpg");
            part2 = Directory.GetFiles(p, "*.jpeg");
            part3 = Directory.GetFiles(p, "*.bmp");
           
            for (int i = 0; i < part1.Length; i++)
            {
                imageList1.Images.Add(Image.FromFile(part1[i]));
                listView1.Items.Add("", i);
                files.Add(part1[i]);
            }
            for (int i = 0; i < part2.Length; i++)
            {
                imageList1.Images.Add(Image.FromFile(part2[i]));
                listView1.Items.Add("", i);
                files.Add(part2[i]);
            }
            for (int i = 0; i < part3.Length; i++)
            {
                imageList1.Images.Add(Image.FromFile(part3[i]));
                listView1.Items.Add("", i);
                files.Add(part3[i]);
            }
            check();
            PhotoPlace.Text = p;
        }
