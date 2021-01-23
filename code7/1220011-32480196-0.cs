             ICriterion criterion;
    
             if(Setting.SomeSettings)    
             {
               criterion = Restrictions.And(
                                **//new restriction**
                                 Restrictions.Eq("Some", user.Some))
                                 Restrictions.Eq("Status", user.Status))
                                 ...
                            ));
            }
            else
            {
               criterion = Restrictions.And(
                              Restrictions.And(                 
                                 Restrictions.Eq("Status", user.Status))
                                 ...
                            ));
            }
    
            new List < ICriterion > {
                        Restrictions.Not(Restrictions.Eq("Name", user.Name)),
                        Restrictions.Or(
                           Restrictions.And(
                            criterion   
                            ...
                     };
