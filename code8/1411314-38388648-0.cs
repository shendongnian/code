     listView1.View = View.Details;
            listView1.Columns.Add("Versiyon No", 133, HorizontalAlignment.Left);
            listView1.Columns.Add("Açıklama", 240, HorizontalAlignment.Left);
            listView1.Columns.Add("Tarih", 150, HorizontalAlignment.Left);
            using (StreamReader sr = new StreamReader("C:\\Users\\user\\Desktop\\proje\\Versiyonlar\\1.1.2\\" + "1.1.2.txt", Encoding.Default))
                {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int sira = listView1.Items.Count;
                    listView1.Items.Add(line.Split(',')[0]);
                    listView1.Items[sira].SubItems.Add(line.Split(',')[1]);
                    listView1.Items[sira].SubItems.Add(line.Split(',')[2]);
                    listView1.Items[sira].SubItems.Add(line.Split(',')[3]);
                    listView1.Items[sira].SubItems.Add(line.Split(',')[4]);
                }
            }
