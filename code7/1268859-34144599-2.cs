     // Instantiate a new Engine object
     Engine engine = new Engine();
     // Point to the path that contains the .NET Framework 2.0 CLR and tools
     engine.BinPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System)
    + @"\..\Microsoft.NET\Framework\v2.0.50727";
     var entityDeploySplitTask = new EntityDeploySplit();
     entityDeploySplitTask.Sources = new ITaskItem[] 
     {
       new TaskItem("Model.edmx")// path to .edmx file from .csproj
     };
     entityDeploySplitTask.BuildEngine = engine;
     entityDeploySplitTask.Execute();
     var entityDeployTask = new EntityDeploy();
     entityDeployTask.Sources = entityDeploySplitTask.NonEmbeddingItems
     entityDeployTask.OutputPath = "."; // path to the assembly output folder
     entityDeployTask.BuildEngine = engine;
     entityDeployTask.Execute();
     var entityDeployTask2 = new EntityDeploy();
     entityDeployTask2.Sources = entityDeploySplitTask.EmbeddingItems
     entityDeployTask2.OutputPath = "C:\Temp"; // path to an intermediate folder
     entityDeployTask2.BuildEngine = engine;
     entityDeployTask2.Execute();
     var entityDeploySetLogicalTask = new EntityDeploySetLogicalNames();
     entityDeploySetLogicalTask.Sources = Directory.EnumerateFiles("C:\Temp", "*.*", SearchOption.AllDirectories)
         .Select(f => new TaskItem(f)).ToArray();
     entityDeploySetLogicalTask.ResourceOutputPath = "C:\Temp"; // path to the intermediate folder
     entityDeploySetLogicalTask.BuildEngine = engine;
     entityDeploySetLogicalTask.Execute();
     foreach(var resourceFile in entityDeploySetLogicalTask.ResourcesToEmbed)
     {
        var fileName = resourceFile.GetMetadata("Identity");
        var logicalName = resourceFile.GetMetadata("LogicalName");
        //TODO: Embed filename using logicalName in the output assembly
        //You can embed them as normal resources by passing /resource to csc.exe
        //eg. /resource:obj\Debug\edmxResourcesToEmbed\Models\SampleEF.csdl,Models.SampleEF.csdl
     }
     //TODO: call EntityClean or just remove all files from the intermediate directory
