        [Test]
        public void Check()
        {
            //var test = new Constructor();
            var test = new AdContextObject();
            
            string distinguishedName = "ComputerDistinguishedName";
            string groupDN = "GroupDistinguished name";
            // Remove the identity from the group so it does crashes if it's already part of it.
            GroupCtrl.RemoveIdentityFromGroup(groupDN, distinguishedName);
            using (var ctx = test.GetContext())
            {
                var group = GroupPrincipal.FindByIdentity(ctx, groupDN);
                Console.WriteLine(group.Members.Count);
                if (!group.Members.Contains(ctx, IdentityType.DistinguishedName, distinguishedName))
                {
                    Console.WriteLine("addGroup");
                    group.Members.Add(ctx, IdentityType.DistinguishedName, distinguishedName);
                    group.Save();
                }
                foreach (var item in group.Members)
                {
                    Console.WriteLine(item.DistinguishedName);
                }
                Console.WriteLine(group.Members.Count);
            }
            DirectoryEntry de = new DirectoryEntry();
            de.Path = "LdapSource";
            DirectorySearcher ser = new DirectorySearcher(de);
            ser.Filter = "(&(ObjectCategory=computer)(name=ComputerName))";
            ser.PropertiesToLoad.Add("name");
            ser.PropertiesToLoad.Add("memberOf");
      var returnValue = ser.FindAll();
            var isMemberOf = false;
            foreach (SearchResult res in returnValue)
            {
                var memberOf = GetMultiValue(res, "MemberOf");
                foreach (var item in memberOf)
                {
                    Console.WriteLine(item);
                    if (item.Equals(groupDN, StringComparison.OrdinalIgnoreCase))
                    {
                        isMemberOf = true;
                    }
                }
            }
            Assert.AreEqual(true, isMemberOf);
            Console.WriteLine("old way worked fine");
            isMemberOf = false;
            using (PrincipalContext ctx = test.GetContext())
            {
                var found = Principal.FindByIdentity(ctx, IdentityType.DistinguishedName, distinguishedName);
                if (found != null)
                {
                    foreach (var item in found.GetGroups())
                    {
                        Console.WriteLine(item.DistinguishedName);
                        
                        if (item.DistinguishedName.Equals(groupDN, StringComparison.OrdinalIgnoreCase))
                        {
                            isMemberOf = true;   
                        }
                    }
                }
                Assert.AreEqual(true, isMemberOf);
            }
            // Reset our group membership to run the test again.
            GroupCtrl.RemoveIdentityFromGroup(groupDN, distinguishedName);
        }
        public static string[] GetMultiValue(SearchResult result, string fieldName)
        {
            string[] returnValue = null;
            if (result != null)
            {
                if (result.Properties.Contains(fieldName))
                {
                    ResultPropertyValueCollection propertyValue = result.Properties[fieldName];
                    if (propertyValue != null)
                    {
                        if (propertyValue.Count > 1)
                        {
                            string[] valueArray = new string[propertyValue.Count];
                            for (int i = 0; i < propertyValue.Count; i++)
                            {
                                string valStr = propertyValue[i].ToString();
                                valueArray[i] = valStr;
                            }
                            returnValue = valueArray;
                        }
                        else if (propertyValue.Count == 1)
                        {
                            string[] tempString = new string[] { propertyValue[0].ToString() };
                            returnValue = tempString;
                        }
                        else
                        {
                            string[] tempString = new string[] { };
                            returnValue = tempString;
                        }
                    }
                }
            }
            return returnValue;
        }
    public class AdContextObject
    {
        public PrincipalContext GetContext()
        {
            return new PrincipalContext(ContextType.Domain, "domainStuff", "MoreDomainStuff");
        }
    }
