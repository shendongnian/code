    List<BasicInfo> BasicInfos = new List<BasicInfo>();
    BasicInfos.Add(new BasicInfo() { Id = 1, Name = "John" });
    BasicInfos.Add(new BasicInfo() { Id = 2, Name = "John" });
    BasicInfos.Add(new BasicInfo() { Id = 3, Name = "Sam" });
    BasicInfos.Add(new BasicInfo() { Id = 4, Name = "Sam" });
    BasicInfos.Add(new BasicInfo() { Id = 5, Name = "Igor" });
    BasicInfos.Add(new BasicInfo() { Id = 6, Name = "joei" });
    var usersWithSameName = BasicInfos.GroupBy(x => x.Name)
        .Where(x => x.Count() > 1)
        .Select(x => x.Single(y => y.Id == x.Min(z => z.Id)));
