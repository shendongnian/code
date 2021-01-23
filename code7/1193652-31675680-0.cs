    [HttpPost]
    public void SetMap(MapRequest req)
    {
        //now you have access to req.MapId
    }
    public class MapRequest
    {
        public int MapId {get;set;}
    }
