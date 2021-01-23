    List<DataTable> DataTableList = new List<DataTable>();
            //fills the list of datatables with a method in another class that
            //access an ms access database
            
            if (DataTableList.Count > 0)
            {
                DataTable sumDataTableList = DataTableList[0].Clone();
                foreach (DataTable table in DataTableList)
                {
                    sumDataTableList.Merge(table);
                }
            }
