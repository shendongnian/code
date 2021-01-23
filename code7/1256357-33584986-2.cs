    var result =
        (from sc in myTargetType.SubCategories
         from stt in sc.SubTargetTypes.Where(t => t.Name.ToLower().Contains(type.ToLower()))
         select new SubTargetResponse
         {
             Id = stt.Id,
             CategoryId = sc.Id,
             Name = stt.Name
         })
        .ToList();
