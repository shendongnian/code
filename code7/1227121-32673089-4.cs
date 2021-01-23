    var items = new List<ItemViewModel>
                {
                    new ItemViewModel {ParentID = 1, Name = "one"},
                    new ItemViewModel {ParentID = 2, Name = "two"},
                    new ItemViewModel {ParentID = 3, Name = "three"}
                };
                ViewBag.Items = items;
                var model = new ItemViewModel();
                //model.ParentId is null here
                return View(model);
