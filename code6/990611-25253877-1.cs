            //reset to false, and recheck for dups
            selectedProductConnection.IsDup = false;
            //check to see if the current item is a dup with anything in the list
            var dups = ProductConnections.Where(o => !ReferenceEquals(o, selectedProductConnection) && o.GetDupHash() == selectedProductConnection.GetDupHash());
            foreach (var pc in dups)
            {
                pc.IsDup = selectedProductConnection.IsDup = true;
            }
            //look for orphaned dup tags
            var grp = new HashSet<int>(
                ProductConnections.Where(o => o.IsDup)
                    .GroupBy(o => o.GetDupHash())
                    .Where(o => o.Count() == 1)
                    .Select(a => a.Key));
            dups = ProductConnections.Where(x => grp.Contains(x.GetDupHash()));
            foreach (var pc in dups)
            {
                pc.IsDup = false;
            }
