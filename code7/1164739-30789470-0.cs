            string listItems;
            foreach(string item in requiredList)
            {
                listItems = listItems + item + ",";
            }
            listItems = listItems.TrimEnd(',');
            DataRow[] table1Rows = table1.Select("ColumnName IN (" + listItems + ")");
            DataRow[] table2Rows = table2.Select("ColumnName IN (" + listItems + ")");
            counter = table1Rows.Count() + table2Rows.Count();
