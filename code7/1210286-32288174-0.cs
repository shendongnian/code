    [Route("Teams")] 
    public ActionResult Teams()
    
    And then I have actions to return data :
    
    //GET : api/Teams
    [HttpGet("api/Teams")]
    public IEnumerable<Team> GetAllTeams()
    
    //GET : api/Teams/5
    [HttpGet("api/Teams/{teamId:int}")]
    public IActionResult GetTeamById(int teamId)
    
    //GET : api/Teams/Chicago Bears
    [HttpGet("api/Teams/{teamName}")]
    public IActionResult GetTeamByName(string teamName)
    
    //POST : api/Teams
    [HttpPost("api/Teams/{team}")]
    public void AddTeam([FromBody]Team item)
    
    //PUT: api/Teams
    [HttpPut("api/Teams/{team}")]
    public void EditTeam([FromBody]Team item)
    
    //DELETE : api/Teams/4
    [HttpDelete("api/Teams/{teamId:int}")]
    public IActionResult DeleteTeam(int id)
