    namespace MyNamespace
    {
        public partial class MainWindow : Window
        {
            IEntity entity;
            private void LoadTables()
            {
                if (Environment.Text == "Production")
                {
                    entity = new ProdEntity();
                }
                else if (Environment.Text == "Development")
                {
                    entity = new DevEntity();
                }
                LoadTable1(); 
             }
   
             private void LoadTable1()
             {
                 entity.SomeTable.ToList();
             }
          }
    }
