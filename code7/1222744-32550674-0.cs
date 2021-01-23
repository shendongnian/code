    public class PasswordRepository
    {
        private const string PasswordName = "ServerPassword";
    
        public void SavePassword(string password)
        {
            using (var cred = new Credential())
            {
                cred.Password = password;
                cred.Target = PasswordName;
                cred.Type = CredentialType.Generic;
                cred.PersistanceType = PersistanceType.LocalComputer;
                cred.Save();
            }
        }
    
        public string GetPassword()
        {
            using (var cred = new Credential())
            {
                cred.Target = PasswordName;
                cred.Load();
                return cred.Password;
            }
        }
    }
