        private void UpdatePhoto()
        {
            var principalContext = new PrincipalContext(ContextType.Domain);
            var userPrincipal = UserPrincipalEx.FindByIdentity(principalContext, System.Environment.UserName);
            DirectoryEntry directoryEntry = new DirectoryEntry(string.Format("LDAP://{0}:389/{1}", principalContext.ConnectedServer, userPrincipal.DistinguishedName));
            directoryEntry.Properties["thumbnailPhoto"].Value = ImageManipulation.imageToByteArray(pictureBoxthumbnail.Image);
            directoryEntry.CommitChanges();
        }
