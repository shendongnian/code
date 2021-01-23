    [AspectTypeDependency( AspectDependencyAction.Order,
                           AspectDependencyPosition.Before,
                           typeof( ObservableNotify ) )]
    [Serializable]
    class ObservableAspect : InstanceLevelAspect
    {
        [IntroduceMember( Visibility = Visibility.Public )]
        public void notifyChange()
        {
            // ...
        }
        // other class members...
    }
    [Serializable]
    class ObservableNotify : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        [ImportMember("notifyChange", IsRequired = true, Order = ImportMemberOrder.AfterIntroductions)]
        public Action notifyChangeMethod;
        public override void OnExit( MethodExecutionArgs args )
        {
            notifyChangeMethod();
        }
        object IInstanceScopedAspect.CreateInstance( AdviceArgs adviceArgs )
        {
            return this.MemberwiseClone();
        }
        void IInstanceScopedAspect.RuntimeInitializeInstance()
        {
        }
    }
