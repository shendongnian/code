    public interface IWizardScreen : IScreen
    {
        AggregateState State { get; }
        Type NextScreenType { get; }
        void Next();
        void Previous();
    }
