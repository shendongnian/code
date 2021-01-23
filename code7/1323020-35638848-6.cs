    var majorList = Enum.GetValues(typeof(MajorList))
                        .Cast<MajorList>()
                        .Select(e => new SelectListItem
                             {
                                 Value =e.ToString(),
                                 Text = e.ToString()
                             });
    ViewBag.MajorList=majorList;
