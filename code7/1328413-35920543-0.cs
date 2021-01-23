    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    
    namespace SO_DataTableCompare
    {
        class Program
        {
            static void Main(string[] args)
            {
                /// Build data and test the underlying method.
                Dictionary<string,Type> columns = new Dictionary<string, Type>();
                columns.Add("emp_num", typeof(int));
                columns.Add("salary", typeof(int));
                columns.Add("ov", typeof(double));
    
                DataTable left = new DataTable();
                foreach (KeyValuePair<string,Type> column in columns)
                {
                    left.Columns.Add(column.Key, column.Value);
                }
                left.Rows.Add(455, 3000, 67.891);
                left.Rows.Add(677, 5000, 89.112);
                left.Rows.Add(778, 6000, 12.672);
                left.Rows.Add(9001, 5500, 12.672);
                left.Rows.Add(4, null, 9.2);
                //left.Dump("Left");
    
                DataTable right = new DataTable();
                right.Columns.Add("outlier", typeof(string));
                foreach (KeyValuePair<string, Type> column in columns)
                {
                    right.Columns.Add(column.Key, column.Value);
                }
                right.Columns.Add("float", typeof(float));
                right.Rows.Add(0, 455, 3000, 67.891, 5);
                right.Rows.Add(1, 677, 5000, 50.113, 5);
                right.Rows.Add(2, 778, 5500, 12.672, 6);
                right.Rows.Add(2, 9000, 5500, 12.672, 6);
                right.Rows.Add(3, 4, 10, 9.2, 7);
                //right.Dump("Right");
    
    
                // Compare.
                DataTable results = Compare(left, right, "emp_num");
                //results.Dump("Results"); // Fancy table output via LINQPad.
    
                // Get the comparison columns for display.
                List<string> comparedColumns = new List<string>();
                foreach (DataColumn column in results.Columns)
                {
                    comparedColumns.Add(column.ColumnName);
                }
    
                // Display the comparison rows.
                Console.WriteLine(string.Join(", ", comparedColumns));
                foreach (DataRow row in results.Rows)
                {
                    Console.WriteLine(string.Join(", ", row.ItemArray));
                }
                Console.ReadKey();
            }
    
            private static DataTable Compare(DataTable left, DataTable right, string keyColumn, string suffix1="_off",string suffix2="_on")
            {
                var columns = left.Columns.OfType<DataColumn>().Select(c => c.ColumnName).ToList();
                var updated = left.Rows.OfType<DataRow>()
                    .Join(right.Rows.OfType<DataRow>(), row => row[keyColumn], row => row[keyColumn], (row1, row2) => new { key = row1[keyColumn], row1, row2 })
                    .Where(o => o.row2!=null && !DataRowSame(o.row1, o.row2, columns));
                //var deleted = left.Rows.OfType<DataRow>().Except(right.Rows.OfType<DataRow>(), new DataRowKeyComparer(keyColumn));
                //var inserted = right.Rows.OfType<DataRow>().Except(left.Rows.OfType<DataRow>(), new DataRowKeyComparer(keyColumn));
                var result = new DataTable();
                result.Columns.Add(keyColumn, left.Columns[keyColumn].DataType);
                int k = 0;
                foreach (var name in columns.Where(c=>c!=keyColumn))
                {
                    k++;
                    result.Columns.Add(name + suffix1, left.Columns[name].DataType);
                    result.Columns.Add(name + suffix2, right.Columns[name].DataType);
                    result.Columns.Add("s"+k, typeof(int));
                }
                result.BeginLoadData();
                foreach (var upd in updated)
                {
                    var vals = new[] { upd.key }.Concat(
                            columns.Where(c => c != keyColumn)
                                .Select(c => new
                                {
                                    l = upd.row1[c],
                                    r = upd.row2[c]
                                })
                                .SelectMany(o => new object[] { o.l, o.r, object.Equals(o.l, o.r) ? 1 : 0 })
                        ).ToArray();
                    result.LoadDataRow(vals, LoadOption.OverwriteChanges);
                }
                result.EndLoadData();
                return result;
            }
    
            private static bool DataRowSame(DataRow row1, DataRow row2, List<string> columns)
            {
                foreach (var name in columns)
                {
                    if (!object.Equals(row1[name], row2[name])) return false;
                }
                return true;
            }
        }
    
        internal class DataRowKeyComparer : IEqualityComparer<DataRow>
        {
            private string keyColumn;
    
            public DataRowKeyComparer(string keyColumn)
            {
                this.keyColumn = keyColumn;
            }
    
            public bool Equals(DataRow x, DataRow y)
            {
                return object.Equals(x[keyColumn], y[keyColumn]);
            }
    
            public int GetHashCode(DataRow obj)
            {
                return obj.GetHashCode();
            }
        }
    }
