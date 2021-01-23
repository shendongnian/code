    static void Main(string[] args)
            {
    
                XL.Application xlapp = new XL.Application();
                xlapp.Visible = true;
                xlapp.Workbooks.Open("c:/test/test_c.xlsm");
                int[] x = new int[] { 1, 2, 3, 4 };
                xlapp.Run("MergeColumnsKeepValues", x, 2, 3, 4,5);
    
            }
