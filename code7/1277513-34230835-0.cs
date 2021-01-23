    var joinedRecords = (
        from m in mTable
            join b in bTable on m.Id equals b.aRefId
            select new {
                aId = a.Id,
                aAttrib1 = a.Attrib1
                ...
                bCmdType = b.CmdType
            }
    ).AsEnumerable() //Executes the query, further you have simple CLR objects
    .Select(o => new {
        aId = o.Id,
        aAttrib1 = o.Attrib1
        ...
        bCmdTypeName = Enum.GetName(typeof(CmdType), o.CmdType)
    });
