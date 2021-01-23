    private MultiSelectList AddStatuses()
            {
                string[] defaultSelected = { "3", "5", "6" };
                List<SelectListItem> allItems = new List<SelectListItem>();
                List<Status> s = allTypes.GetStatuses();
                s.ForEach(status =>
                {
                    allItems.Add(new SelectListItem()
                    {
                        Text = status.Name,
                        Value = status.ID.ToString(),
                    });
                });
                return new MultiSelectList(allItems, "Value", "Text", defaultSelected);
            }
