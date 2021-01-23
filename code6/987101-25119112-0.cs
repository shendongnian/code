    private static void LoadStates()
            {
                using (LeadContextUoW leadContext = new LeadContextUoW())
                {
                    _states = leadContext.States.AllWithNoTracking.ToList();
                    foreach(var state in _states)
                        leadContext.Entry(state).State = System.Data.Entity.EntityState.Detached;
                }
            }
