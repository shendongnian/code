    protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(LoadData().ToPageAsyncTask());
        }
        private Task<DataSet> ExecuteQueryAsync(int numberOfItems)
        {
            return Task.Factory.StartNew(
                () =>
                {
                    var dataSet = new DataSet();
                    var table = new DataTable("Title");
                    table.Columns.Add("Value", typeof(string));
                    dataSet.Tables.Add(table);
                    foreach (var item in Enumerable.Repeat("", numberOfItems).Select(_ => Guid.NewGuid().ToString()))
                    {
                        var row = table.NewRow();
                        row.SetField("Value", item);
                        table.Rows.Add(row);
                    }
                    return dataSet;
                });
        }
        private Task LoadData()
        {
            var t1 = ExecuteQueryAsync(10);
            var t2 = ExecuteQueryAsync(10);
            var t3 = ExecuteQueryAsync(10);
            return Task.Factory.ContinueWhenAll(new[] { t1, t2, t3 }, _ => {
                grid1.DataSource = t1.Result;
                grid1.DataBind();
                grid2.DataSource = t2.Result;
                grid2.DataBind();
                grid3.DataSource = t3.Result;
                grid3.DataBind();
            });
        }
