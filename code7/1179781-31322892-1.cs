    [Serializable]
    class ObservableAspect : InstanceLevelAspect
    {
        private void notifyChange()
        {
            // ...
        }
        // This is the OnExit advice that previously was in a separate aspect.
        [OnMethodExitAdvice]
        [MethodPointcut("SelectMethods")]
        public void OnMethodExit(MethodExecutionArgs args)
        {
            notifyChange();
        }
        // Find all the methods that must be intercepted.
        public IEnumerable<MethodBase> SelectMethods(Type targetType)
        {
            foreach (var methodInfo in targetType.GetMethods())
            {
                if (methodInfo.GetCustomAttributes(typeof (ObservableNotify)).Any())
                    yield return methodInfo;
            }
        }
    }
    class ObservableNotify : Attribute
    {
         // This is just a marker attribute used by ObservableAspect.
    }
