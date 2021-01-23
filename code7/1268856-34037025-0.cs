    var mockObject = new Mock<IBuildEngine>();
    IBuildEngine engine = mockObject.Object;
    var entityDeployTask = new EntityDeploy();
    entityDeployTask.Sources = new ITaskItem[] 
    {
      new TaskItem(@"path to edmx\Model1.edmx")
    };
    entityDeployTask.OutputPath = @"C:\";
    entityDeployTask.BuildEngine = engine;
    entityDeployTask.Execute();
