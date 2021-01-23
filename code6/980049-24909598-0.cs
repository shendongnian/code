    var selectListItem = ServiceProductModel
        .GetAll()
        .Select(spm => new SelectListItem {
            Value = spm.Id.ToString(),
            Text = string.Format(@"{0}", spm.Name)
        })
        .ToList();
