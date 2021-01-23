    public class FeatureFactory: IFeatureFactory
    {
        IFeature CreateFeature(string input)
        {
             if(input=="SomeFeature")
             {
               return new SomeFeature();
             }
             else
             {
               return new OtherFeature ();
             }
        }
    }
