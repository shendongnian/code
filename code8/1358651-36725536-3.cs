        public static ListItemViewModel CreateViewModel(MyViewModel parent, Test entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new ListItemViewModel(parent)
            {
                Date = entity.Date,
                IsSelected = entity.IsSelected,
            };
        }
