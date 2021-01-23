    var prematches = (from user in _memberRepository.All()
    				  where user.Zone == currentUser.Zone &&
    						user.Time == currentUser.Time &&
    						user.HouseOfUser.Any(g => currentUser.HouseOfUser.Any
    												 (
    													x => x.CityId == g.CityId
    															&&
    														 x.Value == g.Value
    												 )
    											)
    				  select user).ToList();
