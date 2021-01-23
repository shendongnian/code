        DisplayColumns
        .Select(s=> {
                        s.IsSelected = (s.ColumnName == "Bug" && s.ColumnName == "Feature");
                        return s;   
                    });
