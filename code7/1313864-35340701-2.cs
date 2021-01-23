     public List<DataGridItem> SelectedItem
        {
            get
            {
                return list.Where(item=>item.IsSelected).ToList();
            }
        }
