    public class Fruits
        {
    
            public int ID { get; set; }
    
            public string Name{ get; set; }
    }
    
    
    var Val = fruitList.GroupBy(x => x.ID,
                             (key, y) => y.MaxBy(x => x.ID).value)
