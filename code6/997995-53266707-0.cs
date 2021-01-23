    public class BaseSteps
    {
        [Given(@"Method called")]
        public virtual void WhenMethodCalled()
        {
           
        }
    }    
    [Binding]
    [Scope(Feature= "specific_feature")
    public class DerivedSteps : BaseSteps
    {
        [Given(@"Method called")]
        [Scope(Feature= "specific_feature", Tag ="specific_tag")]
        public override void WhenMethodCalled()
        {
           
        }
    }
