    List<string> dTitle = new List<string>();
    List<string> dSku = new List<string>();
    List<string> dPrice = new List<string>();
    List<string> dDesc = new List<string>();
    List<string> dImage = new List<string>();
    
    foreach (DataGridViewRow r in dgvProducts.SelectedRows)
    {
    	dSku.Add(r.Cells[1].Value.ToString());
    	dTitle.Add(r.Cells[2].Value.ToString());
    	dPrice.Add(r.Cells[3].Value.ToString());
    	dDesc.Add(r.Cells[4].Value.ToString());
    	dImage.Add(r.Cells[5].Value.ToString());
    }
