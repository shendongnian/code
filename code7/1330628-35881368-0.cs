    public IActionResult Get() {
        try {
            IEnumerable<MyEntity> result;
            //...result populated
           return new ObjectResult(result);
        } catch (Exception ex) {
            //You should handle the error
            HandleError(ex);//the is not an actual method. Create your own.
            //You could then create your own error so as not to leak
            //internal information.
            var error = new System.Web.HttpException("Enter you user friendly error message");
            InternalServerError(error);
        }
    }
