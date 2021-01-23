    @(Html.Kendo().Grid<T>()
        .Name("grid")
        .Sortable(sortable => sortable.SortMode(GridSortMode.MultipleColumn))
        .DataSource(dataSource => dataSource
            .Ajax()
            .Sort(s =>
                    {
                        s.Add(l => l.F_NAME).Descending();
                        s.Add(l => l.L_NAME).Descending();                        
                    })
        ....)
