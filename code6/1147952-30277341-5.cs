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
        if ((assignment.Source != null && assignment.Source.Type != null && assignment.Source.Type.Name.Name == "MyStruct") ||
            (assignment.Target != null && assignment.Target.Type != null && assignment.Target.Type.Name.Name == "MyStruct"))
        {
            Problem problem = new Problem(GetNamedResolution("Struct", assignment.Target.Type.Name.Name), assignment);
            Problems.Add(problem);
        }
        base.VisitAssignmentStatement(assignment);
    }
    public override void VisitConstruct(Construct construct)
    {
        Method targetMethod = (Method)((MemberBinding)construct.Constructor).BoundMember;
        if (targetMethod.Parameters.Any(x => x.Type.Name.Name == "MyStruct"))
        {
            Problem problem = new Problem(GetNamedResolution("ParameterType", "MyStruct", targetMethod.Name.Name), construct);
            Problems.Add(problem);
        }
        base.VisitConstruct(construct);
    }
    public override void VisitMethodCall(MethodCall call)
    {
        Method targetMethod = (Method)((MemberBinding)call.Callee).BoundMember;
        if (targetMethod.ReturnType.Name.Name == "MyStruct")
        {
            Problem problem = new Problem(GetNamedResolution("ReturnType", targetMethod.ReturnType.Name.Name, targetMethod.Name.Name), call);
            Problems.Add(problem);
        }
        if (targetMethod.Parameters.Any(x => x.Type.Name.Name == "MyStruct"))
        {
            Problem problem = new Problem(GetNamedResolution("ParameterType", "MyStruct", targetMethod.Name.Name), call);
            Problems.Add(problem);
        }
        base.VisitMethodCall(call);
    }
