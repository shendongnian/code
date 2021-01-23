    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Reflection;
    using Microsoft.PowerShell;
    ...
    InitialSessionState iss = InitialSessionState.CreateDefault();
    // Override ExecutionPolicy
    PropertyInfo execPolProp = iss.GetType().GetProperty(@"ExecutionPolicy");
    if (execPolProp != null && execPolProp.CanWrite)
    {
    	execPolProp.SetValue(iss, ExecutionPolicy.Bypass, null);
    }
    Runspace rs = RunspaceFactory.CreateRunspace(iss);
    rs.Open();
