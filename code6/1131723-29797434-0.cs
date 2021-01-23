    namespace UserAction
    {
       public class NewUserAction<T> : RuleAction<T> where T : RuleContext
       {
          public override void Apply(T ruleContext)
          {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
          }
       }
    }
