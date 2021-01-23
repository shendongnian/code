    public class CustomerMap : ClassMap<Customer>
    {
         public CustomerMap()
         {
             // map customer properties
             Component(Reveal.Member<Customer>("MainAddress"), m =>
             {
                 m.Map(x => x.Address1, "MainAddress1");
                 m.Map(x => x.Address2, "MainAddress2");
                 // other address properties
             };
             Component(Reveal.Member<Customer>("ShipAddress"), m =>
             {
                 m.Map(x => x.Address1, "ShipAddress1");
                 m.Map(x => x.Address2, "ShipAddress2");
                 // other address properties
             };
             // same for english address
        }
    }
