      // team member has one role at this building
           References(t => t.TeamRole)
               .ForeignKey("TeamRoleFK")                                
               .Columns(new string[] {"RoleId", "UnifiedDbCode"})
               .Not.Update()
               .Not.Insert();
