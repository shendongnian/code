    public class CustomJsonResult : JsonResult
    {
        private const string _dateFormat = "yyyy-MM-dd HH:mm:ss";
        public override void ExecuteResult(ControllerContext context)
        {
            try
            {
                base.ExecuteResult(context);
            }
            catch(Exception ex)
            {
                //Handle it
            }
        }
