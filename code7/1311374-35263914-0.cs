    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Building a dataset having 10 different datatable which contains 1 column each
                DataSet ds = new DataSet();            
                for (int i = 0; i <= 9; i++)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("dt" + i + "_column1", typeof(string));
                    dt.AcceptChanges();
                    ds.Tables.Add(dt);
    
                }
                ds.AcceptChanges();
                //Here finally building a datatable which consists all columns of each and every tables in dataset
                DataTable dtFinal = new DataTable();
                foreach (DataTable tmp in ds.Tables)
                {
                    dtFinal.Merge(tmp);
                }
            }
        }
    }
