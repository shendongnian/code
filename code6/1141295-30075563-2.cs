     class myBus : IBus
     {
         public void Publish<T>(Action<T> messageConstructor)
         {
             IPremiumAdjustmentFinalised paf = new PremiumAdjustmentFinalised();
             var ipaf = (T) paf;
             messageConstructor(ipaf);
             Assert.AreEqual(paf.Amount, AdjustmentAmount);
             Assert.AreEqual(paf.FinalisedOn, LastModifiedOn);
             Assert.AreEqual(paf.PolicyNumber, PolicyNumber);
         }
         ...
         <<Leave the rest of the methods not implemented>>
         ...
     }
