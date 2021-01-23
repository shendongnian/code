     static void Main(string[] args)
     {
          using (var db = new CallContext())
          {
              var snapshot = db.Calls.Where(x => x.team == "T1").ToList();
          }
     }
