    public void AddCurrencyColumn(Expression<Func<T, decimal?>> expression)
            {
                Func<T, decimal?> compiledExpression = expression.Compile();
                this.Columns.Add(new WebGridColumn()
                {
                    ColumnName = "Id",
                    Header = string.Empty,
                    Format = (item) => string.Format(System.Globalization.CultureInfo.CurrentCulture, "$ {0}", compiledExpression(item.Value)),
                    Style = "currency-webgrid-column"
                });
            }
