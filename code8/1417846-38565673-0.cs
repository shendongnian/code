     for (int i = 0; i < gridView1.RowCount; i++)
            {
                var rosw = gridView1.GetDataRow(i);
                var genre = rosw["genre"].ToString();
                int tmpg = 0;
               // //tmpg = genre.IndexOf(textBox8.Text, StringComparison.OrdinalIgnoreCase);
                if (genre.IndexOf(textBox8.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    //if (tmpg >= 1)
                   // MessageBox.Show(genre);
                   
                    gridView1.FocusedRowHandle = i;
                    break;
                }
            }
