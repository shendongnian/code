            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string genre = gridView1.GetDataRow(i)["genre"].ToString();
                // Check if the genre already existed or not
                if (!comboBox1.Items.Contains(genre))
                {
                    comboBox1.Items.Add(genre);
                }
            }
