    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder builder = new StringBuilder();
    
        // Show the Environment Information
        builder.AppendLine("<h2>Environment Information</h2>");
        builder.Append("<b>Machine Name: </b>" + Environment.MachineName + "<br>");
        builder.Append("<b>OS Version: </b>" + Environment.OSVersion + "<br>");
        builder.Append("<b>Is 64Bit Operating System: </b>" + Environment.Is64BitOperatingSystem + "<br>");
        builder.Append("<b>Processor Count: </b>" + Environment.ProcessorCount + "<br>");
        builder.Append("<b>User Name: </b>" + Environment.UserName + "<br>");
        builder.Append("<b>Is Debugger Attached: </b>" + Debugger.IsAttached + "<br>");
    
        // Show the Process Information
        builder.AppendLine("<h2>Processes Information</h2>");
        foreach (Process process in Process.GetProcesses())
            builder.AppendLine(process.ProcessName + "</br>");
    
        // Show the RoleEnvironment Information
        builder.AppendLine("<h2>Role Environment Information</h2>");
        builder.Append("<b>Curent Role Instance Name: </b>" + RoleEnvironment.CurrentRoleInstance.Role.Name + "<br>");
        builder.Append("<b>Deployment Id: </b>" + RoleEnvironment.DeploymentId + "<br>");
        builder.Append("<b>Is Emulated: </b>" + RoleEnvironment.IsEmulated + "<br>");
    
        // Display the Resutls
        InfoLabel.Text = builder.ToString();
    }
