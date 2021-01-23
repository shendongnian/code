                if (!(context.DistributorApplicationUsers.Any(u => u.UserName == userName)))
                {
                    var userStore = new UserStore<DistributorApplicationUser>(context);
                    var userManager = new DistributorApplicationUserManager(userStore);
                    var userToInsert = new DistributorApplicationUser { UserName = userName, Email = email, EmailConfirmed = true, Distributor = distributor };
                    IdentityResult result = userManager.Create(userToInsert, password);
                }
                if (!(context.AgentApplicationUsers.Any(u => u.UserName == userName)))
                {
                    var userStore = new UserStore<AgentApplicationUser>(context);
                    var userManager = new AgentApplicationUserManager(userStore);
                    var userToInsert = new AgentApplicationUser { UserName = userName, Email = email, EmailConfirmed = true, Agent = agent };
                    IdentityResult result = userManager.Create(userToInsert, password);
                }
                if (!(context.SubagentApplicationUsers.Any(u => u.UserName == userName)))
                {
                    var userStore = new UserStore<SubagentApplicationUser>(context);
                    var userManager = new SubagentApplicationUserManager(userStore);
                    var userToInsert = new SubagentApplicationUser { UserName = userName, Email = email, EmailConfirmed = true, Subagent = subagent };
                    IdentityResult result = userManager.Create(userToInsert, password);
                }
