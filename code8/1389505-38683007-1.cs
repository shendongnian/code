    public class SelectionControl : UserControl, IFormViewControl
    {
        ...
        public void Initialize(FormView view)
        {
            var snapIn = view.ScopeNode.SnapIn;
            ...
        }
    }
