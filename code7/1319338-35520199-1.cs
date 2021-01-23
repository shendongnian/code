     foreach (var client in Clients )
     {
            model.WebPagesViewModel.Clients .Add(item: new SelectListItem()
            {
                Text = dept.DepartmentName,
                Value = dept.DepartmentId.ToString()
            });
        }
