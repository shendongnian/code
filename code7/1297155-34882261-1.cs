    Guard.Ensure(someObject, "someObject")
         .IsNotNull()
         .Property(x => x.ChildProp1, "childProp1", childProp1 =>
             childProp1.IsNotNull()
                       .IsLessThan(10)
                       .Property(y => y.InnerChildProperty, "innerChildProperty", innerChildProperty =>
                           innerChildProperty.IsNotNull()
                        )
         )
         .Property(x => x.ChildProp2, "childProp2", childProp2 =>
             childProp2.IsNotNull()
                       .IsGreaterThan(10)
         );
