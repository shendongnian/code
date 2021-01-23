    namespace EF {
        class Program {
            static void Main(string[] args) {
    
                using (var ctx = new GeneralContext()) {
                    SalesRepresentative emp = new SalesRepresentative() { Name = "Prashant" };
                    ctx.SalesRepresentatives.Add(emp);
                    ctx.SaveChanges();
                }
            }
        }
    }
