    class EvManager {
        private SumDelegate sum;
        public void ExecuteIt(int a, int b) {
            var invocationList = sum.GetInvocationList();
            foreach (var m in invocationList) {
                var concreteMethodName = m.Method.Name;
            }   
        }
    }
    
