    using System;
    using System.Data;
    using System.Data.SqlClient;
    namespace SqlBulkInsertExample
    {
    class Program
    {
      static void Main(string[] args)
      {
            DataTable prodSalesData = new DataTable("ProductSalesData");
            // Create Column 1: SaleDate
            DataColumn dateColumn = new DataColumn();
            dateColumn.DataType = Type.GetType("System.DateTime");
            dateColumn.ColumnName = "SaleDate";
            // Create Column 2: ProductName
            DataColumn productNameColumn = new DataColumn();
            productNameColumn.ColumnName = "ProductName";
            // Create Column 3: TotalSales
            DataColumn totalSalesColumn = new DataColumn();
            totalSalesColumn.DataType = Type.GetType("System.Int32");
            totalSalesColumn.ColumnName = "TotalSales";
            // Add the columns to the ProductSalesData DataTable
            prodSalesData.Columns.Add(dateColumn);
            prodSalesData.Columns.Add(productNameColumn);
            prodSalesData.Columns.Add(totalSalesColumn);
            // Let's populate the datatable with our stats.
            // You can add as many rows as you want here!
            // Create a new row
            DataRow dailyProductSalesRow = prodSalesData.NewRow();
            dailyProductSalesRow["SaleDate"] = DateTime.Now.Date;
            dailyProductSalesRow["ProductName"] = "Nike";
            dailyProductSalesRow["TotalSales"] = 10;
            // Add the row to the ProductSalesData DataTable
            prodSalesData.Rows.Add(dailyProductSalesRow);
            // Copy the DataTable to SQL Server using SqlBulkCopy
            using (SqlConnection dbConnection = new SqlConnection("Data Source=ProductHost;Initial Catalog=dbProduct;Integrated Security=SSPI;Connection Timeout=60;Min Pool Size=2;Max Pool Size=20;"))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = prodSalesData.TableName;
                    foreach (var column in prodSalesData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(prodSalesData);
                }
            }
        }
    }
    }
