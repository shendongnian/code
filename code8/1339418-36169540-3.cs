    var data =
        (from t in doc.Elements("TRANSACTION")
        select new
        {
            // assuming the indices are sequential
            DeleteFromItems = t.Elements("Delete").Zip(t.Elements("DeletefromItem"), (d, dfi) => new
                {
                    ItemId = (int)dfi, // assuming there's a value
                    UniqueId = (string)d,
                }).ToList(),
            InsertIntoItems = t.Elements("Insert").Zip(t.Elements("InsertinItem"), (i, iii) => new
                {
                    ItemId = (int)iii, // assuming there's a value
                    UniqueId = (string)i,
                }).ToList(),
            UpdateIntoItems = t.Elements("Update").Zip(t.Elements("UpdateinItem"), (u, uii) => new
                {
                    ItemId = (int)uii, // assuming there's a value
                    UniqueId = (string)u,
                }).ToList(),
            ItemId = (string)t.Element("itemid"),
            PrimaryItem = new
            {
                Id = (int)t.ElementIndex("item", "a"),
                IsNew = (bool)t.ElementIndex("savenewitem", "a"),
                LabelType = (string)t.ElementIndex("itemlabeltype", "a"),
                Type = (string)t.ElementIndex("itemtype", "a"),
            },
            SecondaryItem = new
            {
                Id = (int)t.ElementIndex("item", "b"),
                IsNew = (bool)t.ElementIndex("savenewitem", "b"),
                LabelType = (string)t.ElementIndex("itemlabeltype", "b"),
                Type = (string)t.ElementIndex("itemtype", "b"),
            },
        }).Single();
