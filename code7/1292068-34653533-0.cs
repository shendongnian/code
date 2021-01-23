            var interestIds = db.Interests.Where(i => i.Name.Contains("interest_name"))
                            .Select(i => i.InterestId)
                            .ToList().ConvertAll(i=>i.ToString());
            //var profiles = new List<UserProfile>();
            var allProfiles = (from UserProfile up in db.UserProfiles
                         from i in interestIds
                          where up.Interests.Contains(i)
                         select up).ToList();
            return allProfiles;
            //string sId = null;
            //foreach (var id in interestIds)
            //{
            //    sId = id.ToString();
            //    profiles.AddRange(db.UserProfiles
            //        .Where(p => p.Interests.Contains(sId))
            //        .ToList());
            //}
            //return profiles;
