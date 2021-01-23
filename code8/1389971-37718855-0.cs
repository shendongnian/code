    @using System.Collections.Generic;
    @using System.Web.Mvc;
    @using TestcaseRepository.Controllers;
    
    @functions {
        public static bool HasPrivilege(ViewDataDictionary<dynamic> privileges, Type privilege)
        {
            string name = privilege.Name;
            if (name.EndsWith("Attribute"))
            {
                name = name.Substring(0, name.Length - "Attribute".Length);
            }
    
            return ((ISet<string>)privileges[ViewDataKeys.Privileges]).Contains(name);
        }
    }
