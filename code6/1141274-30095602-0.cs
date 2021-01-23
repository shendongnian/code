        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ...
            DateTime date = new DateTime(year, month, day);
            ...
            return date;
        }
