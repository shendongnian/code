    var yesterday =DateTime.Today.AddDays(-1);
    
    var events = context.Events.Where(x=>x.PremiereDateTimeInUtc>=yesterday)
        .GroupBy(x=>x.Subtopic.TopicId, (k,g)=>new{
            TopicId=k,
            Event=g.OrderBy(e=>e.PremiereDateTimeInUtc).FirstOrDefault()
        });
    
    var topics = context.Topics.GroupJoin(events, t=>t.Id, e=>e.TopicId,(t,g)=>new{
            Topic=t,
            FirstEvent=g.FirstOrDefault(),
            Subtopic=g.FirstOrDefault().Subtopic
        });
