       [EnableQuery(PageSize = 10)]
        public IQueryable Get()
        {
            var data = GetData(db,"DimUsers");
            return Okay(data, data.GetType());
        }
 
        protected IHttpActionResult Okay(object content, Type type)
        {
            var resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);
            return Activator.CreateInstance(resultType, content, this) as IHttpActionResult;
        }
