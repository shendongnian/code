    void Main()
    {
      List<Topic> topicA = new List<Topic>() { new Topic() { ID = 1, Name = "1" }, new Topic() {ID = 2 , Name = "2"}, new Topic() {ID = 3, Name = "3" } };
      List<Topic> topicB = new List<Topic>() { new Topic() { ID = 2, Name = "2" }, new Topic() {ID = 3 , Name = "3"}, new Topic() {ID = 4, Name = "4" } };
      List<Topic> topicC = new List<Topic>() { new Topic() { ID = 1, Name = "1" } };
      List<Topic> topicD = new List<Topic>() { new Topic() {ID = 2 , Name = "2"}, new Topic() {ID = 3, Name = "3" } };
      
      List<Status> statusA = new List<Status>() { new Status() { ID = 1, Name = "pass" }, new Status() {ID = 2 , Name = "2"}, new Status() {ID = 3, Name = "3" } };
      List<Status> statusB = new List<Status>() { new Status() { ID = 2, Name = "2" }, new Status() {ID = 3 , Name = "pass"}, new Status() {ID = 4, Name = "pass" } };
      List<Status> statusC = new List<Status>() { new Status() { ID = 1, Name = "pass" } };
      List<Status> statusD = new List<Status>() { new Status() {ID = 2 , Name = "2"}, new Status() {ID = 3, Name = "pass" } };
    
    
      List<CFS> test = new List<CFS>() { 
                          new CFS() { FirstName = "A", LastName = "A", Email = "A@A.com", Topics = topicA, Status = statusA },
                          new CFS() { FirstName = "B", LastName = "B", Email = "B@B.com", Topics = topicB, Status = statusB },
                          new CFS() { FirstName = "C", LastName = "C", Email = "C@C.com", Topics = topicC, Status = statusC },
                          new CFS() { FirstName = "D", LastName = "D", Email = "D@D.com", Topics = topicD, Status = statusD },
      };
      
     
      var result = test.SelectMany(x => x.Topics.SelectMany((t) => x.Status, (topic,status) => new { CFS = x, T = topic, S = status }))
                        .Where(x => x.S.Name == "pass" &&  x.T.ID == x.S.ID)
                        .Select(x => new {  first = x.CFS.FirstName, status = x.S.Name, topic = x.T.Name})
                        .GroupBy(x => x.topic)
                        .Select(x => new SelectedTopic { Topic = x.Key, Status = "pass", Person = x.Select(z => z.first).Distinct().ToList() })
                        .Dump();
      
    }
