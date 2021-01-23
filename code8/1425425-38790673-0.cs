      public class Resolver : ValueResolver<SourceClass, string>
       {
        protected override string ResolveCore(SourceClass source)
        {
            var dc = new DestinationClass();
            if (source.SourceLists.Any())
            {
                foreach (var sourceList in source.SourceLists)
                {
                    //if the source list Type1 is true, add the value of the list to the value1
                    if (sourceList.Type1.Equals(true))
                    {
                        dc.Value1 = sourceList.Value.ToString(CultureInfo.InvariantCulture);
                        source.SourceLists.RemoveAt(0);
                        return dc.Value1;
                    }
    
                    if (sourceList.Type2.Equals(true))
                    {
                        dc.Value2 = sourceList.Value.ToString(CultureInfo.InvariantCulture);
                        source.SourceLists.RemoveAt(0);
                        return dc.Value2;
                    }
    
                    if (sourceList.Type3.Equals(true))
                    {
                        dc.Value3 = sourceList.Value.ToString(CultureInfo.InvariantCulture);
                        source.SourceLists.RemoveAt(0);
                        return dc.Value3;
                    }
                }
            }
            return String.Empty;
        }
    }
