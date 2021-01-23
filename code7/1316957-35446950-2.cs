    public List<Thing> RetrieveThings()
    {
      List<Thing> output;
      using (Context context = new Context())
        output = (from t in context.Things
                   select new Thing() {
                      Id = t.Id, Name = t.Name
                   }
                 ).ToList();
      return output;
    }
