    var ouName = "OU=" + "VIP"; //VIP will be the name of OU.
    using(DirectoryEntry de = new DirectoryEntry("LDAP://MyIp/OU=NEW,OU=MyUsers,DC=MyServer,DC=com"))
    {
       de.Username = "administrator";
       de.Password = "mypassword";
       de = de.Children.Add(ouName, "OrganizationalUnit");
       de.CommitChanges();
    }
