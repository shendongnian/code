    public class RequiresGenericPrincipalAttribute : BeforeAfterTestAttribute
    {
        private IPrincipal _originalPrincipal;
        public override void Before(MethodInfo methodUnderTest)
        {
            _originalPrincipal = System.Threading.Thread.CurrentPrincipal;
            System.Threading.Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(""), new String[] { });
            base.Before(methodUnderTest);                        
        }
        public override void After(MethodInfo methodUnderTest)
        {
            base.After(methodUnderTest);
            System.Threading.Thread.CurrentPrincipal = _originalPrincipal;
        }
    }
