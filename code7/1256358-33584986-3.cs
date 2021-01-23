    var result =
        myTargetType.SubCategories.SelectMany(
            sc => sc.SubTargetTypes.Where(stt => stt.Name.ToLower().Contains(type.ToLower())),
            (sc, stt) => new SubTargetResponse
            {
                 Id = stt.Id,
                 CategoryId = sc.Id,
                 Name = stt.Name
            })
        .ToList();
