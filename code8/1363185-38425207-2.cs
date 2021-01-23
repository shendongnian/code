      public class ConditionCreator
      {
         private Decision decision;
         public ConditionCreator()
         {
            decision = new Decision(this);
         }
         public Decision Add()
         {
            return decision;
         }
         public class Decision
         {
            private ConditionCreator creator;
            public Decision(ConditionCreator creator)
            {
               this.creator = creator;
            }
            public ConditionCreator And()
            {
               return creator;
            }
            public ConditionCreator Or()
            {
               return creator;
            }
            public Condition Create()
            {
               return new Condition();
            }
         }
      }
