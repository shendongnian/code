     public double Weight { get; private set; } // probably you don't need setter
    
     public void AddWeights(IEnumerable<Role> roles)
     {
         const double RoleWeight = 1;
         const double PrimaryRoleWeight = 3;
    
         if (!roles.Any())
            return;
    
         if (Roles == null || !Roles.Any())
             return;
    
         var pirmaryRole = roles.First();
         var comparison = StringComparison.CurrentCultureIgnoreCase;
         
         if (String.Equals(Roles[0], primaryRole, comparison))
         {
             Weight += PrimaryRoleWeight;
             return;
         }
    
         foreach(var role in roles)         
            if (Roles.Contains(role, StringComparer.CurrentCultureIgnoreCase))
                Weight += RoleWeight;
     } 
