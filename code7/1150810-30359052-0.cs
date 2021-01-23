    public class ViewModel
            {
                public DataTable dt { get; set; }
    
                public ViewModel()
                {
                    dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Col1", typeof(String)));
                    dt.Columns.Add(new DataColumn("Col2", typeof(String)));
                    dt.Columns.Add(new DataColumn("ButtonsList", typeof(ButtonsList)));
    
                    dt.Rows.Add("Test1", "Test1", new ButtonsList { Content = "ButtonTest1", ToolTip = "TooltipTest1" });
                    dt.Rows.Add("Test2", "Test2", new ButtonsList { Content = "ButtonTest2", ToolTip = "TooltipTest2" });
                }
            }
