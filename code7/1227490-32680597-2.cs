        [HttpPost]
        public JsonResult Destinations(IEnumerable<string> userOptions)
        {
            // do something with userOptions...
            JsonResult result = new JsonResult();
            result.Data = someData;
            return (result);
        }
