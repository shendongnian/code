    [Serializable]
    public class DetectWhenFlowExitsClass : OnMethodBoundaryAspect
    {
        [ThreadStatic] private static Dictionary<Type, int> stackCounters;
        private Type declaringType;
        public override bool CompileTimeValidate(MethodBase method)
        {
            declaringType = method.DeclaringType;
            return true;
        }
        private void EnsureStackCounters()
        {
            if (stackCounters == null)
                stackCounters = new Dictionary<Type, int>();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            EnsureStackCounters();
            int counter;
            stackCounters.TryGetValue(declaringType, out counter);
            stackCounters[declaringType] = ++counter;
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            EnsureStackCounters();
            int counter;
            stackCounters.TryGetValue(declaringType, out counter);
            stackCounters[declaringType] = --counter;
            if (counter == 0)
                Console.WriteLine("Control leaving class {0}", declaringType.Name);
        }
    }
