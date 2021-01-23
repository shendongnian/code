    Page 1:**ttt.aspx**
    public class **tttPage : BasePage 
    {
        protected override GridView GetGridView()
        {
            //return GridView of this page 
            return GridView1;
        }
        public override DataTable GetAllData()
        {
            using (var context = new MyDataContext())
            {
               var data = from c in context.ttt select c;
               return MyDataContext.LINQToDataTable(data);
            }
        }
    }
    Page 1:**bbb.aspx**
    public class **bbbPage : BasePage 
    {
        protected override GridView GetGridView()
        {
            //return GridView of this page 
            return GridView1;
        }
        public override DataTable GetAllData()
        {
            using (var context = new MyDataContext())
            {
               var data = from c in context.bbb select c;
               return MyDataContext.LINQToDataTable(data);
            }
        }
    }
