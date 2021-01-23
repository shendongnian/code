    DataGridViewImageColumn dgColMemos = new DataGridViewImageColumn();
    dataGridView1.Columns.Add(dgColMemos);
    dataGridView1.RowCount = 3;
    for (Int16 r = 0; r < dataGridView1.RowCount; r++)
    {
        ImagesTag I3 =
            new ImagesTag(imageList2.Images[r * 3], 
                imageList2.Images[r * 3 + 1], imageList2.Images[r * 3 + 2]);
        dataGridView1[0, r].Value = I3.Img1;
        dataGridView1[0, r].Tag = I3;
    }
