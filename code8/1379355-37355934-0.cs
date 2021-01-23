    new NotificationTeam
                        {
                            Title = Encoding.ASCII.GetString(Encoding.Unicode.GetBytes(team.Value<string>("teamName"))),
                            TeamID = team.Value<int>("tid"),
                            Followers = team.Value<int>("followers")
                        })
