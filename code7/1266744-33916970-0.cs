    private List<object> ReturnListFounds(string text)
            {
                List<object> result = new List<object>();
    
                for (int l = 0; l <= Items.Count; l++)
                {
                    var cell = new GridViewCellInfo(this.Items[l], this.Columns[0], this);
    
                    if (cell.Item != null)
                    {
                        var props = cell.Item.GetType().GetProperties();
    
                        foreach (var p in props)
                        {
                            if (p == null || cell.Item == null)
                                continue;
    
                            var t = p.GetValue(cell.Item);
    
                            if (t == null)
                                continue;
    
                            var str = t.ToString();
                            if (str.Equals(text, StringComparison.InvariantCultureIgnoreCase) || str.ToLower().Contains(text))
                            {
                                result.Add(cell.Item);
                            }
    
                        }
                    }
    
                }
    
                result = new List<object>(result.Distinct());
    
                return result;
            }
