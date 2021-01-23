    public static class DbExtensions {
      public static object[] ToObjectArray(this ClassA ca) {
        return new object[]{ca.ID,ca.Name};
      }
    }
    List<ClassB> result=this.Database
      .SqlQuery<ClassB>("GetSomeList", ClassA.ToObjectArray())
      .ToList<ClassB>();
