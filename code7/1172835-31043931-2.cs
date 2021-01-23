        public void InitilizeModelData()
        {
            // In gernal, the data comes from database
            var model = new CaculatorModel()
            {
                IsChecked = True,
            };
            IsChecked = model.IsChecked;
        }
