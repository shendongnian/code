     public static void GetUsersFromIdsAndClaims(this SPFieldUserValueCollection collection, SPWeb web, string inputValue)
            {
                var values = Regex.Split(inputValue, ";#");
                for (var i = 0; i < values.Count(); i += 2)
                {
                    var id = int.Parse(values[i]);
                    var value = values[i + 1];
                    var user = id == -1 ? web.EnsureUser(value) : web.SiteUsers.GetByID(id);
    
                    collection.Add(new SPFieldUserValue(web, user.ID, user.Name));
                }
            }
        }
