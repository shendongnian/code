    public static bool IsInRole(this User user, string role, int projectID)
    {
        var isInRole = user.IsInRole(role);
        var hasRoleInProject = // Logic for deciding if it is in the role for this project
    
        return isInRole && hasRoleInProject; 
        
    }
