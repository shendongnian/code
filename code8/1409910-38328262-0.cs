    var selectList = new List<SelectListItem>();
    
    foreach (var element in stringlist)
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = element.ToString(),
                            Text = element.ToString()
                        });
                    }
    
    return Json(selectList, JsonRequestBehavior.AllowGet);
