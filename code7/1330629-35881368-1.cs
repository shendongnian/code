    public IActionResult Get() {
        try {
            IEnumerable<MyEntity> result;
            //...result populated
           return new HttpOkObjectResult(result);
        } catch (Exception ex) {
            //You should handle the error
            HandleError(ex);//the is not an actual method. Create your own.
            //You could then create your own error so as not to leak
            //internal information.
            var error = new System.Web.HttpException("Enter you user friendly error message");
            //So far I am not finding any documentation on internal errors for MVC6 so failing that I'm just throwing the error
            throw error;
        }
    }
