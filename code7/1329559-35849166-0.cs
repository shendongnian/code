     DropDownListItem item = (
                        from c in context.Practitioners
                        where c.PractitionerID == id
                        select new DropDownListItem
                        {
                            Id = c.PractitionerID,
                            DisplayValue = c.FirstName ?? "" + " " + c.MiddleName ?? "" + " " + c.LastName ?? "",
                            IsActive = c.IsActive,
                            DisplayOrder = c.PractitionerID,
                            CreatedById = new Guid("COFFEEOO-LOVE-LIFE-LOVE-C0FFEEC0FFEE"),
                            CreatedDate = c.CreatedDate,
                        }).FirstOrDefault() ?? new DropDownListItem();
    
                    response.Data = item;
