    [TestMethod]
    public void AllWebApiControllersShouldDeriveFromApiController()
    {
        var controllers = Assembly.GetAssembly(typeof(ApiControllerBase)).GetTypes()
            .Where(t => t.Namespace == "Xxx.Web.Controllers"
            && IsCompilerGenerated(t) == false).ToList();
    
        controllers.Should().NotBeEmpty();
    
        foreach (var controller in controllers)
        {
            if (controller == typeof(ApiControllerBase)) continue;
    
            controller.Should().BeDerivedFrom<ApiControllerBase>();
        }
    }
    private static bool IsCompilerGenerated(MemberInfo t)
    {
        return Attribute.GetCustomAttribute(t, typeof(CompilerGeneratedAttribute)) != null;
    }
