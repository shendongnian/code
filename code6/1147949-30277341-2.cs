    using Microsoft.FxCop.Sdk;
    
    namespace MyCustomFxCopRules
    {
        public class StructAssignmentFinder : BaseIntrospectionRule
        {
            public StructAssignmentFinder()
                : base("StructAssignmentFinder", "MyCustomFxCopRules.RuleMetadata", typeof(StructAssignmentFinder).Assembly)
            {
                var ms = new MyStruct();
                var tt = ms;
            }
    
            public struct MyStruct
            {
    
            }
    
            public override TargetVisibilities TargetVisibility
            {
                get
                {
                    return TargetVisibilities.All;
                }
            }
    
            public override ProblemCollection Check(ModuleNode module)
            {
                Visit(module);
                return Problems;
            }
    
            public override void VisitAssignmentStatement(AssignmentStatement assignment)
            {
                // You could even use FullName
                if (assignment.Target.Type.Name.Name == "MyStruct")
                {
                    Problem problem = new Problem(GetNamedResolution("Struct", assignment.Target.Type.Name.Name), assignment);
                    Problems.Add(problem);
                }
    
                base.VisitAssignmentStatement(assignment);
            }
        }
    }
