    using System;
    using System.DirectoryServices.ActiveDirectory;
    namespace LDAPTEST
    {
        public class Program
        {
             static void Main(string[] args)
             {
                 DirectoryContext s = new DirectoryContext(DirectoryContextType.Domain, "DC=hq,DC=xxxxxxxxx,DC=com", "TestUsername", "TestPassword");
    
                 Domain domain = Domain.GetDomain(s);
                 Forest forest = domain.Forest;
                 DomainCollection domains = forest.Domains;
                 foreach (Domain objDomain in domains)
                 {
                      Console.Write("");
                 }  
             }
         }
    }
