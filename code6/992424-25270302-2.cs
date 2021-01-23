    public static Identity CreateIdentity(Customer from)
    {
         Identity newId = null;
         //call other factory....
         if (from.IsOrganization)
         {
             newId =  OrgnaizationIdentity.FromIdentity(from);
         }
         else
         {
             newId = IndividualIdentity.FromIdentity(from);
         }
         //populate Identity private attribs here...
    } 
