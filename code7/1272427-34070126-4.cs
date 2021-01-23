    var dtos = cntx.Tasks.Include( at => at.Attachments ).FirstOrDefault(t => t.Id == id ).Select(x => new TaskDto 
    {
      Id = x.Id,
      Attachments = x.Attachments.Select(y => new AttachmentsDto { Id = y.Id }).ToList()
    });
