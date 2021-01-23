    public class MyPrincipal : IPrincipal
    {
        public IPrincipal FormsPrincipal { get; private set; }
        public MyPrincipal(IPrincipal formsPrincipal)
        {
            FormsPrincipal = formsPrincipal;
        }
    
        public bool IsInRole(string role)
        {
            if (someCondition)
            {
                // check roles for this
            }
            else
            {
                return FormsPrincipal.IsInRole(role); // check role against the other principal
            }
        }
    }
