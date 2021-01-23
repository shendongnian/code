    public string GetExtendedAttribute(string attributeName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            var cp = ComputerPrincipalEx.FindByIdentity(ctx, Name);
            return cp.ExtensionGet(attributeName);
        }
