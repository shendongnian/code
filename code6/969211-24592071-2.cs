    [DirectoryObjectClass("computer")]
    [DirectoryRdnPrefix("CN")]
    public class ComputerPrincipalEx : ComputerPrincipal
    {
        public ComputerPrincipalEx(PrincipalContext context) : base(context) { }
        public ComputerPrincipalEx(PrincipalContext context, string samAccountName, string password, bool enabled) : base(context, samAccountName, password, enabled) { }
        new public string ExtensionGet(string extendedattribute)
        {
            try
            {
                if (base.ExtensionGet(extendedattribute).Length != 1)
                {
                    return null;
                }
                else
                {
                    return (string)base.ExtensionGet(extendedattribute)[0];
                }
            }
            catch (Exception ex)
            {
                // This should be broken down to individual exceptions
                string message = string.Format("Exception occurred while retrieving extended attribute {0}. \r\nThe following error occurred:\r\n {1}", extendedattribute, ex);
                MessageBox.Show(message);
                Application.Exit();
                return null;
            }
        }
        public static new ComputerPrincipalEx FindByIdentity(PrincipalContext ctx, string identityValue)
        {
            return (ComputerPrincipalEx)FindByIdentityWithType(ctx, typeof(ComputerPrincipalEx), identityValue);
        }
    }
