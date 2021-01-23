     for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (i % 2 == 0)
                    listView1.Items[i].BackColor = Color.Blue; 
                else
                    listView1.Items[i].BackColor = Color.White; 
            }
