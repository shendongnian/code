        private static DateTime? GetLastLoginToMachine(string machineName, string userName)
        {
            try
            {
                var c = new PrincipalContext(ContextType.Machine, machineName);
                using (var uc = UserPrincipal.FindByIdentity(c, userName))
                {
                    if (uc != null) return uc.LastLogon;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.CreateFile(ex);
            }
            return null;
        }
