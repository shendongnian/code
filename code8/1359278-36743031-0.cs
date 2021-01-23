       String strName = "name";
        bool contains = dtCurrentTable.AsEnumerable().Any(row => strName == row.Field<String>("intFrom"));
        String strName2 = "name";
        bool contains2 = dtCurrentTable.AsEnumerable().Any(row => strName2 == row.Field<String>("intTo"));
        if (contains && contains2)
        {
            // Do your code
        }
    }
