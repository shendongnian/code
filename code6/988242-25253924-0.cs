     public void TagDup(ProductConnection selectedProductConnection)
        {
            selectedProductConnection.IsDup = false;
            //check to see if the 'current' item is a dup with anything in the list
            ProductConnections.Where(o => !ReferenceEquals(o, selectedProductConnection) && o.GetDupHash() == selectedProductConnection.GetDupHash()).ToList().ForEach(o => o.IsDup = selectedProductConnection.IsDup = true);
            //look for orphaned dup tags
            var grp = ProductConnections.Where(o => o.IsDup).GroupBy(o => o.GetDupHash()).Where(o => o.Count() == 1).ToList();
            ProductConnections.Where(x => grp.Select(a => a.Key).Contains(x.GetDupHash())).ToList().ForEach(o => o.IsDup = false);
        }
