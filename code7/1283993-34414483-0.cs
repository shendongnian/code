        public IEnumerable<SelectListItem> ListGroupEnabled()
        {
            List<SelectListItem> X = _entities.Groups.Select(c => new SelectListItem { Value = c.GroupId.ToString(), Text = c.Name , Disabled = c.IsEnabled }).ToList();
            return X;
        }
