        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool _LoadingData = false;
        private bool _DataChanged = false;
        private void LoadData()
        {
            try
            {
                _LoadingData = true;
                // Load data
            }
            finally
            {
                _LoadingData = false;
            }
        }
        public void DataChanged()
        {
            if (_LoadingData == false)
            {
                _DataChanged = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }
