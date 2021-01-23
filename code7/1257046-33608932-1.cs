    _db.tbl_itembundle
        .Where(x => x.type == 2)
        .Select(y => new ItemBundleDTO
        {
            name = y.name,
            namekey = y.namekey.
            contents = y.tbl_itembundlecontents.AsQueryable().Select(ToSingleItemDTO())
        });
