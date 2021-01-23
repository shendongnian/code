    GetGroupMembers(PSObject groupObject) {
            object membersValue = groupObject.Properties["Member"].Value;
            object[] members;
            // Does the group have any members?
            if (membersValue == null)
                return null;
            // If the group has only one member, then it won't be an object Array but rather a PSObject
            if (membersValue.GetType() == typeof(PSObject))
            {
                members = new object[] {membersValue};
            }
            else
            {
                // The group has more than one member, in this case we can cast it to an object array
                members = ((object[])membersValue);
            }
            // use PSObject to access the object's properties
            foreach (PSObject member in members)
            {
                string objectClass = member.Properties["ObjectClass"].Value.ToString();
                Guid objectGuid = new Guid (member.Properties["objectGuid"].Value.ToString());
                ADObject memberObject;
                switch (objectClass)
                {
                    case "user":
                        // You might want to check for null here as well before getting the values from these properties
                        string givenName = member.Properties["GivenName"].Value.ToString();
                        string surname = member.Properties["Surname"].Value.ToString();
                        string displayName = member.Properties["DisplayName"].Value.ToString();
                        [...]
