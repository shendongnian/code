     internal static class Program
        {
            private static void Main(string[] args)
            {
                string[] array = new [] { "Hi", "Hello"};
                DataSet dataSet = array.AssignToDataSet();
            }    
        
        
            private static DataSet AssignToDataSet(this string[] myArray)
            {
                DataSet dataSet = new DataSet();
                DataTable dataTable = dataSet.Tables.Add();
                dataTable.Columns.Add();
                Array.ForEach(myArray, c => dataTable.Rows.Add()[0] = c);
                return dataSet;
            }
        }
