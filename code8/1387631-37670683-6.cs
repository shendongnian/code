    public class AuditingActionResult : ActionResult
    {
        private readonly ActionResult innerActionResult;
        public AuditingActionResult(ActionResult innerActionResult)
        {
            if (innerActionResult == null)
                throw new ArgumentNullException("innerActionResult");
            this.innerActionResult = innerActionResult;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            // Do auditing here...
            innerActionResult.ExecuteResult(context);
        }
    }
