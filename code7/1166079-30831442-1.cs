    public class ProgressiveResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            for (int i = 0; i < 20; i++)
            {
                context.HttpContext.Response.Write(i.ToString());
                Thread.Sleep(2000);
                context.HttpContext.Response.Flush();
            }
            context.HttpContext.Response.End();
        }
    }
