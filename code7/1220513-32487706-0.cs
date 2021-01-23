    public bool AddUsersToLeaderBoard() {
        var db = Connection.GetDatabase();
        var list = SeedUsers();
        var numOfSuccesses = 0;
        foreach (var item in list) {
            var r = db.SortedSetAdd("test", JsonConvert.SerializeObject(item), item.Score);
            if (r) numOfSuccesses++;
        }
        var i = list[3];
        //i.Score = 888; - this line can be removed
        db.SortedSetAdd("test", JsonConvert.SerializeObject(i), 888);
        return numOfSuccesses == list.Count;
    }
