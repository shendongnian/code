    var groups = GraphUtil.GetMemberGroups(context.AuthenticationTicket.Identity).Result;
                            //For each group, we have its, ID, we need to get the display name, and then we have to add the claim
                            foreach(string groupid in groups)
                            {
                                var displayname=GraphUtil.LookupDisplayNameOfAADObject(groupid, context.AuthenticationTicket.Identity);
                                context.AuthenticationTicket.Identity.AddClaim(new Claim("roles", displayname));
                            }
