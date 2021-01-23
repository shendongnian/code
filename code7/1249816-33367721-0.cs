        [Test]
        public void GetCustomerData()
        {
            DataTable TradeFinanceBF3 = GetTable();
            DataTable NewDatatable = TradeFinanceBF3.Clone();
            IList<string> CustName = new List<string> { "Janet", "David" };
            var selectedTable = (from dataRow in TradeFinanceBF3.AsEnumerable()
                join customerName in CustName on dataRow.Field<string>("Cust_Name") equals customerName
                select new
                {
                    CustName = dataRow["Cust_Name"],
                    IndexABC = dataRow["IndexABC"]
                }).OrderByDescending(p=>p.IndexABC);
            foreach (var table in selectedTable)
            {
                NewDatatable.Rows.Add(table.CustName, table.IndexABC);
            }
            Console.Write(NewDatatable);
        }
        private DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Cust_Name", typeof(string));
            table.Columns.Add("IndexABC", typeof(double));
            // Here we add five DataRows.
            table.Rows.Add("David", 1);
            table.Rows.Add("Sam", 2);
            table.Rows.Add("Christoff",2);
            table.Rows.Add("Janet", 4);
            table.Rows.Add("Melanie", 6);
            return table;
        }
