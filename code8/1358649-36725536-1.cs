        public static ListItemViewModel CreateViewModel(Test entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new ListItemViewModel
            {
                Date = entity.Date,
                IsSelected = entity.IsSelected,
            };
        }
