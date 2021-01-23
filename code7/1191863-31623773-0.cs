        public class RootObject
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
        var o = new List<RootObject>();
        for (var i = 0; i < 100; ++i)
        {
           o.Add(new RootObject
           {
              Code = "foo",
              Name = "bar"
           });
        }
       var v = JsonConvert.SerializeObject(o);
