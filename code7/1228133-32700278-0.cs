        using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
            ComputerPrincipal computer = ComputerPrincipal.FindByIdentity(ctx, "mylinuxservername");
            if (computer != null)
            {
                var unObject = computer.GetUnderlyingObject() as System.DirectoryServices.DirectoryEntry;
                if(null != unObject)
                {
                    var osProperty = unObject.Properties.Cast<System.DirectoryServices.PropertyValueCollection>().Where(p => p.PropertyName == "operatingSystem");
                    if(null != osProperty.FirstOrDefault())
                    {
                        Console.WriteLine(osProperty.FirstOrDefault().Value);
                    }
                }
            }
        }    
