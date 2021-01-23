    foreach (SortDescription sd in sortDescriptions)
    {
        OccupationsDataGrid.Items.SortDescriptions.Add(sd);
        foreach (var col in OccupationsDataGrid.Columns.Where(aa => aa.SortMemberPath == sd.PropertyName))
        {
            col.SortDirection = sd.Direction;
        }
    }
