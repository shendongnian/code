    class Model
    {
        public string Name { get; set; }
        public int InstanceID { get; set;}
      //Other properties
    }
    List<Model> models = new List<Model>();
    var groups = models.GroupBy(m => m.Name);
    foreach (var group in groups)
    {
        int index = 0;
        foreach (var item in group)
            item.InstanceID = index++;
    }
