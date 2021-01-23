    class SecondForm
    {
        public SecondForm(object dataSource)
        {
            InitializeComponents();
    
            dataGridView.DataSource = dataSource;
        }
    }
