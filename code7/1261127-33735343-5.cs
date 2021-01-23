    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      ImagesTag I3 = (ImagesTag)(dataGridView1[e.ColumnIndex, e.RowIndex].Tag);
      int current = (int)(I3.CurrentImg);
      int next = ++current % 3;
      dataGridView1[0, e.RowIndex].Value = next == 0 ? I3.Img1 : next == 1 ? I3.Img2 : I3.Img3;
      I3.CurrentImg = next;
      dataGridView1[0, e.RowIndex].Tag = I3;
    }
