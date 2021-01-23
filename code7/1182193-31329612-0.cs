                get
                {
                    var table = new DataTable();
                    table.Columns.Add("Date", typeof (string));
                    table.Columns.Add("Gross Revenue", typeof(string));
                    table.Columns.Add("Our Revenue", typeof(string));
                    table.Columns.Add("Cost", typeof(string));
                    table.Columns.Add("Profit", typeof(string));
                    table.Columns.Add("ROI", typeof(string));
                    table.Columns.Add("RPC", typeof(string));
                    table.Columns.Add("Clicks", typeof(long));
                    table.Columns.Add("Conversions", typeof(long));
                    table.Columns.Add("Conversion Rate", typeof(string));
                    table.Rows.Add(
                        Date.ToString("MM/dd/yyyy"),
                        GrossRevenue.ToString("C"),
                        OurRevenue.ToString("C"),
                        Cost.ToString("C"),
                        Profit.ToString("C"),
                        Roi.ToString("P"),
                        Rpc.ToString("P"),
                        Clicks,
                        Conversions,
                        ConversionRate.ToString("P")
                    );
                    return table;
                }
            }
