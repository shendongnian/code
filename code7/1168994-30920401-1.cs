    bool exists = (from a in Global.Application
                    join Global.Role as r on a.ID equals r.ApplicationId
                    join Global.[Authorization] as auth on a.ID equals auth.ApplicationId
                    join Global.[User] as user on auth.UserId equals user.ID
                    where a.EnableApplication == 1
                    && a.EnableAuthorization == 1
                    && a.EnableRoles == 1
                    && a.ID == 1
                    && r.Name == "GlobalAdmin"
                    && r.ID == auth.RoleId
                    && user.UserPrincipalName == "domain\username"
                    select a.ID).Any();
