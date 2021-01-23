    //Gets the Load() extention method available for DbSet
    using System.Data.Entity;
    
        private void Bind()
        {
            myEntity.table.Load();
            //Local returns an obvervable collection convenient for data binding
            var obsColl = myEntity.table.Local;
            someDatagrid.ItemsSource = obsColl;
        }
