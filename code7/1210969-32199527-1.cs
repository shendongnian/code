     this.GridView1.CellClick += new System.Windows.Forms.GridViewCellEventHandler(this.GridView1_CellClick);
    private void GridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        string id = GridView1.Rows[GridView1.CurrentRow.Index].Cells["ID"].Value.ToString();
        textBox1.Text = id;
      }
      catch (Exception)
      {
      }
    }
