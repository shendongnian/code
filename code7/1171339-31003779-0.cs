    string argumentName = "TestDirectory";
    var process = Microsoft.TeamFoundation.Build.Workflow.WorkflowHelpers.DeserializeProcessParameters(BuildDefinition.ProcessParameters);
                               
    if (process.ContainsKey(argumentName))                             
    {
        process.Remove(argumentName);
        process.Add(argumentName, attributeValue);
        BuildDefinition.ProcessParameters = WorkflowHelpers.SerializeProcessParameters(process);
        BuildDefinition.Save();
    }
