    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
            {
                bool authenticated;
                authenticated = pc.ValidateCredentials(userName, password);
                if (authenticated)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
