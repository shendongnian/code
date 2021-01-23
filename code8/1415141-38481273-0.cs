    cvm.AreaList = db.Areas.Where(a => a.IsDeleted == false).ToList().Select(a => new SelectListItem()
    {
          Value = a.AreaID.ToString(),
          Text = a.DisplayName
    });
