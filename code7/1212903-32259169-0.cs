    public class WindowsIdentityHelper
    {
        public WindowsPrincipal GetWindowsPrincipal()
        {
            //Get Current AppDomain
            AppDomain myDomain = Thread.GetDomain();
            myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            return (WindowsPrincipal)Thread.CurrentPrincipal;
        }
        public bool IsUserBelongsToWindowsAdministratorGroup()
        {
            WindowsPrincipal myPrincipal = GetWindowsPrincipal();
            if (myPrincipal.IsInRole("Administrators"))
                return true;
            if (myPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                return true;
            else
                return false;
        }
        public string GetFullDomainLoginUserName()
        {
            WindowsPrincipal myPrincipal = GetWindowsPrincipal();
            return myPrincipal.Identity.Name.ToString();
        }
        public string GetLoginUserName()
        {
            string authenticatedUser = string.Empty;
            string userName = GetFullDomainLoginUserName();
            if (userName.Contains("\\"))
                authenticatedUser = userName.Split('\\')[1];
            else
                authenticatedUser = userName;
            return authenticatedUser;
        }
    }
