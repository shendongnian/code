    private void dgv_expenditure_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        DataGridViewRow dgv = dgv_expenditure.Rows[e.RowIndex];
        int id = Convert.ToInt32(dgv.Cells[0].Value);
        tabControl1.SelectedIndex = 1;
    
        loadform(id);
    }
    private void loadform(int id)
    {
        //   throw new NotImplementedException();
        SanmolCAEntities1 _db = new SanmolCAEntities1();
    
        var u = _db.a_expenditure.Where(p => p.id == id).FirstOrDefault();
        txt_name.Text = u.name;
        txt_CreateBy.Text = u.createby;
        dateTimePicker_excrdate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        txt_updateBy.Text = u.updateby;
        dateTimePicker_exupdate.Value.ToString("yyyy-MM-dd HH:mm:ss");
    }
