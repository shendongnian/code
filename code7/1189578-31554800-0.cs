    IEnumerable<IEnumerable<User>> GetListOfListsOfUsers(int xTimes)
    {
        for (int i = 1; i <= xTimes; i++)
        {
            var someUsers = context.UserBooleanAttributes
                                   .Where(x => x.UserAttributeID == i && x.Value == true)
                                   .Select(a => a.User);
            yield return someUsers;
        }
    }
    var listOfListsOfUsers = GetListOfListsOfUsers(xTimes);
