    public class DistanceResult
    {
      public Type SharedAncestor { get; private set; }
      public int FirstTypeDistance { get; private set; }
      public int SecondTypeDistance { get; private set; }
      public DistanceResult(Type sharedAncestor, int firstTypeDistance, int secondTypeDistance)
      {
        SharedAncestor = sharedAncestor;
        FirstTypeDistance = firstTypeDistance;
        SecondTypeDistance = secondTypeDistance;
      }
    }
    static DistanceResult CalculateDistance(Type firstType, Type secondType)
    {
      var firstChain = new List<Type>();
      while (firstType != typeof(object))
      {
        firstChain.Add(firstType);
        firstType = firstType.BaseType;
      }
      firstChain.Add(typeof(object));
      var secondChain = new List<Type>();
      while(secondType != typeof(object))
      {
        secondChain.Add(secondType);
        secondType = secondType.BaseType;
      }
      secondChain.Add(typeof(object));
      for(var i = 0; i < secondChain.Count; i++)
      {
        var type = secondChain[i];
        int index = firstChain.IndexOf(type);
        if (index >= 0)
        {
          return new DistanceResult(firstChain[index], index, i);
        }
      }
      return null;
    }
