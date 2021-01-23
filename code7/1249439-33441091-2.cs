    public class Engine
    {
        public  List<StrategyAction>    registeredActions   = new List<StrategyAction>();
        private List<StrategyAction>    queuedActions       = new List<StrategyAction>();
        public IStrategyResult Execute(string action, ISerializable info = null)
        {
            if (this.registeredActions.FirstOrDefault(a=>a.Name == action) == null) return null;
            // This code did not appear to be used anyway
            //var returnType = typeof (IStrategyResult<>);                                              //var genericReturn = returnType.MakeGenericType(strategyAction.ResponseType);
            var instance = (IStrategy) UnityManager.Container.Resolve(typeof(IStrategy), action);
            return instance.Execute(info);
        }
        public List<IStrategyResult> ExecuteQueuedActions()
        {
            var results         = new List<IStrategyResult>();
            var actions         = this.queuedActions.AsQueryable();
            var sortedActions = TopologicalSort.Sort(actions, action => action.Dependencies, action => action.Name);
            foreach(var strategyAction in sortedActions)
            {
                this.queuedActions.Remove(strategyAction);
                results.Add(Execute(strategyAction.Name));
            }
            return results;
        }
    }
