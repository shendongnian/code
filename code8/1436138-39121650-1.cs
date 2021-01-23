    public class WrappedJsonResult : JsonResult
    {
        public new object Data
        {
            get
            {
                if (base.Data == null)
                {
                    return null;
                }
                return (object) ((dynamic) base.Data).Object.Body;
            }
            set { base.Data = new {Object = new {Body = value}}; }
        }
    }
