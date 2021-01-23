    public class PropertyManagerPage2Handler9Wrapper : IPropertyManagerPage2Handler9
    {
        readonly IPropertyManagerPage2Handler9 _Implementation;
        public PropertyManagerPage2Handler9Wrapper(IPropertyManagerPage2Handler9 implementation)
        {
            _Implementation = implementation;
        }
        public void AfterActivation()
        {
            _Implementation.AfterActivation();
        }
        public void OnClose(int Reason)
        {
            _Implementation.OnClose(Reason);
        }
        public void AfterClose()
        {
            _Implementation.AfterClose();
        }
        <snip>
    }
