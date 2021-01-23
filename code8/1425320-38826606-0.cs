    [TestClass]
    public class ControllerDependencyTests : ControllerUnitTests {
        [TestMethod]
        public void All_Controllers_Should_Depend_Upon_Abstractions() {
            var controllers = UnitTestHelper.GetAssemblySources() //note this is custom code to get the assemblies to reflect.
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => typeof(IController).IsAssignableFrom(t) || typeof(System.Web.Http.Controllers.IHttpController).IsAssignableFrom(t));
            var constructors = controllers
                .SelectMany(type => type.GetConstructors())
                .Where(constructor => {
                    var parameters = constructor.GetParameters();
                    var result = constructor.IsPublic
                        && parameters.Length > 0
                        && parameters.Any(arg => arg.ParameterType.IsClass && !arg.ParameterType.IsAbstract);
                    return result;
                });
            // produce a test failure error mssage if any controllers are uncovered
            if (constructors.Any()) {
                var errorStrings = constructors
                    .Select(c => {
                        var parameters = string.Join(", ", c.GetParameters().Select(p => string.Format("{0} {1}", p.ParameterType.Name, p.Name)));
                        var ctor = string.Format("{0}({1})", c.DeclaringType.Name, parameters);
                        return ctor;
                    }).Distinct();
                Assert.Fail(String.Format("\nType depends on concretion instead of its abstraction.\n{0} Found :\n{1}",
                                errorStrings.Count(),
                                String.Join(Environment.NewLine, errorStrings)));
            }
        }
    }
