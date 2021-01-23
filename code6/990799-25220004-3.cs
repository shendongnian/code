    public String TeamsAsJson{ get{
              JavaScriptSerializer Serializer = new JavaScriptSerializer();
              return Serializer.Serialize(JsonConvert.SerializeObject(TeamHelpers.GetAllTeams(), Formatting.None));
          }
              private set { TeamsAsJson = value; }
          }
