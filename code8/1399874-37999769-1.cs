                var idA = 614;
                var idB = 130;
                var context = DbModel.ContextManager.Prism.dbo(DBName_Static);
                var custA = context.Customer.Where(x => x.Id == idA);
                var custB = context.Customer.Where(x => x.Id == idB);
                //different results (correct)
                var custA_forcedBefore = custA.ToList();
                var custB_forcedBefore = custB.ToList();
                //change the value of the input params to be the same
                idA = idB;
                //same results (incorrect). Because execution was deferred til after the parameter values were changed
                var custA_forcedAfter = custA.ToList();
                var custB_forcedAfter = custB.ToList();
