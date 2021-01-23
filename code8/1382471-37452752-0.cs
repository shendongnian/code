         public class Details
            {
                public string name { get; set; }
                public string city { get; set; }
            }
    
      var res = JsonConvert.DeserializeObject<Details[]>(json);
      var name = res[0].name;
