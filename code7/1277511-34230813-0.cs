    var joinedRecord =
        (from m in mTable
        join b in bTable on m.Id equals b.aRefId)
        .AsEnumerable()
        .Select(x =>  new {
            aId = a.Id,
            aAttrib1 = a.Attrib1
            ...
            bCmdType = Enum.GetName(typeof(CmdType), b.CmdType)
        })
       .WithTranslations();
