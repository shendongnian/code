    class Model
    {
        public string Name { get; set; }
      //Other properties
    }
    List<Model> models = new List<Model>();
    models.GroupBy(m => m.Name)
          .Select(g => new 
           {
               Name = g.Key, 
               Items = g.Select((m, i) => new 
                         { 
                             Model = m, 
                             InstanceId = i 
                         }
           }));
