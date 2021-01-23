    var joinedRecord =
    (
        from m in mTable
        join b in bTable on m.Id equals b.aRefId
        select new {
            aId = a.Id,
            aAttrib1 = a.Attrib1
            ...
            bCmdType = b.CmdType
        }
    )
    .AsEnumerable() // or ToList()
    .Select( // map to another type calling Enum.GetName(typeof(CmdType), b.CmdType) )
    .WithTranslations();
