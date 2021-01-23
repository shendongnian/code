    public ActionResult Index(string input)
    {
        Guid guidOutput;
        bool isId = Guid.TryParse(input, out guidOutput);
        bool isAlias = !isId;
       var room = isId ?
                  db.Rooms.FirstOrDefault(r => r.RoomLink == input) :
                  db.Rooms.FirstOrDefault(r => r.Alias == input);
    }
