    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    public class TestHandler : AuthorizationHandler<TestRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
    public class TestRequirement : IAuthorizationRequirement
    {
        
    }
