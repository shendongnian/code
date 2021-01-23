            public JsonResult getData()
            {
                try
                {
                    var stringlist = object.getstrlist().select( x=> new SelectListItem
                                 {
                                  Value = x,
                                  Text = x
                                 }).ToList();
                   
                    return Json(stringlist, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
