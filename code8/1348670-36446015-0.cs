    GetGroupMembers(PSObject groupObject) {
            // You might want to check if the property exists at all here
            object[] members = ((object[])groupObject.Properties["Member"].Value);
            // use PSObject to access the object's properties
            foreach (PSObject member in members)
            {
                string objectClass = member.Properties["ObjectClass"].Value.ToString();
                Guid objectGuid = new Guid (member.Properties["objectGuid"].Value.ToString());
                ADObject memberObject;
                switch (objectClass)
                {
                    case "user":
                        string givenName = member.Properties["GivenName"].Value.ToString();
                        string surname = member.Properties["Surname"].Value.ToString();
                        string displayName = member.Properties["DisplayName"].Value.ToString();
                        [...]
