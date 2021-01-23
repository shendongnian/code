    [HttpGet]
    public string GetCurrentPrincipal()
    {
         var curr = System.Security.Principal.WindowsIdentity.GetCurrent();
         return curr == null ? string.Empty : curr.Name;
    }
