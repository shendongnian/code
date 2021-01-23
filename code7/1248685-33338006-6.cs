    using (var writer = new StreamWriter("NewProject.csproj", false, Encoding.UTF8))
    {
        var project = ProjectRootElement.TryOpen("my template.csproj");
        project.AddItem("Content", "miss piggy.png");
        project.Save(writer);
    }
