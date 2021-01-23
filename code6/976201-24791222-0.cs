    var query =
            from col in viewData
            group col by new
        {
            col.name,
            col.number,
            
        } into groupedCol
        select new viewData()
        {
            number = groupedCol.Key.number,
            name = groupedCol.Key.name,
            datetime = groupedCol.OrderBy( dateCol => dateCol.datetime).First()
            
        };
        
