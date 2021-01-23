    var lastResultItem = result.Last();
    response.AllChecklist[0].obj = new TObj{
        lastResultItem.Name,
        lastResultItem.Category,
        lastResultItem.Code,
        chk = result.Select(r => new TChk{
            r.Name,
            r.Type,
            r.chktatusCode,
            r.chktatusReasonCode
        }).ToList()
    });
