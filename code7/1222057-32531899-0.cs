    		DataGridView dgv = new DataGridView() { Dock = DockStyle.Fill };
    		BindingList<Ability> list = new BindingList<Ability>();
    		dgv.AutoGenerateColumns = true;
    		dgv.DataSource = list;
    
    		int colCount = dgv.Columns.Count; // 0
            //--------
            // force columns to be created
    		using (var g = dgv.CreateGraphics()) {}
    		using (var f = new Form()) {
    			f.Controls.Add(dgv);
    			f.Controls.Remove(dgv);
    		}
            //--------
    		int colCount2 = dgv.Columns.Count; // 4
