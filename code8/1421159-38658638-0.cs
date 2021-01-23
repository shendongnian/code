    var list = new List<BaseA>
    {
         new AA(),
         new AB(),
         new AC(),
    }
    var aa = list[0] as AA;
    if (aa != null)
    {
        var id = aa.AID;
    }
