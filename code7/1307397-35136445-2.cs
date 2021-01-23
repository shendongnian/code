    [OperationContract]
    [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "getEvtTypesCnt")]
    Dictionary<string,EvtTypes> GetEvtTypesCnt();
    public Dictionary<string,EvtTypes> GetEvtTypesCnt()
    {
        var data = new StHomeDBDataContext();
        var list = new List<EvtTypes>();
        foreach (var r in data.GetAllEvtTypesCnt_ToList())
        {
            list.Add(new EvtTypes
            {
                EvtType = r.evtType,
                EvtCnt = Convert.ToInt32(r.evtCnt)
            });
        }
        Dictionary<string,List<EvtType>> map =
           new Dictionary<string,List<EvtType>>();
        map.Add("evtType", list);
        return map;
    }
