    public void SetControlsSortOrder(ColumnSortOrder sortOrder)
        bandedGridView.BeginSort();
        try {
           bandedGridView.ClearSorting();
           colName.SortOrder = sortOrder;
        }
        finally {
           bandedGridView.EndSort();
        }
    }
