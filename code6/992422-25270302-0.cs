    public static Identity CreateIdentity(Identity from)
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
