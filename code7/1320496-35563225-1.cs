    var userList = from user in users
                    join gul in globalUserList on user.ID = gul.ID
                    join oob in context.OrganizationObjectBridges on user.ID = oob.oob_object.id
                    where oob.oob_object_type_id == 9
                    select new User2
                    {
                        ID = user.ID,
                        GlobalLogin = gul.GlobalLogin,
                        FirstName = user.FirstName,
                        GUID = gul.GUID,
                        Customer = customer,
                        Organization = orgs.FirstOrDefault(o => o.ID == n.oob.oob_org_id)
                    };
