    public class ControllerCommandMatcher : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            // or whatever other condition to bail out quickly
            if (model.Implementation.Name.EndsWith("Controller") == false) return;
    
            foreach (var constructor in model.Constructors)
            {
                foreach (var dependency in constructor.Dependencies)
                {
                    if (dependency.TargetItemType != typeof (ICommand)) continue;
                    dependency.Parameter = new ParameterModel(dependency.DependencyKey,
                        ReferenceExpressionUtil.BuildReference(dependency.DependencyKey));
                }
            }
        }
    }
