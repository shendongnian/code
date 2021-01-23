    public class Order {
      public int ID { get; set; }  
      public string Foo { get; set; }
    }
    
    public class OrderDTO {
      public int ID { get; set; }
      public string Foo { get; set; }
    }
    
    ...
    
    Mapper.CreateMap<Order, OrderDTO>()
      .ForMember(e => e.Foo, o => o.Condition((ResolutionContext c) => !c.Options.Items.ContainsKey("IWantToSkipFoo")));
    
    ...
    
    var target = new Order();
    target.ID = 2;
    target.Foo = "This should not change";
    
    var source = new OrderDTO();
    source.ID = 10;
    source.Foo = "This won't be mapped";
    
    Mapper.Map(source, target, opts => { opts.Items["IWantToSkipFoo"] = true; });
    Assert.AreEqual(target.ID, 10);
    Assert.AreEqual(target.Foo, "This should not change");
