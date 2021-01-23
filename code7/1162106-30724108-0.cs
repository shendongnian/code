     public List<int> GetCurrentlyVisibleRowProductIDs()
     {
          List<int> productIDs = new List<int>();
    
          foreach (DataGridViewRow row in dgvReplenish.Rows)
          {
                  productIDs.Add((int)row.Cells[(int)ProductColumnIndex.ID].Value);
    
         }
        return productIDs;
     }
