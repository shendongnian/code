    List<string> errors = new List<string>();
    for (int index = 0; index < this.gridagree.Rows.Count; index++)
    {
        int productId = Convert.ToInt32(gridagree.Rows[index].Cells[3].Text);
        string productname = gridagree.Rows[index].Cells[4].Text;
        int quantityRequested = Convert.ToInt32(gridagree.Rows[index].Cells[5].Text);
        int availableQuantity = Convert.ToInt32(s.getprodqun(productId));
        if (quantityRequested > availableQuantity)
        {
            errors.Add(productname);
        }
    }
