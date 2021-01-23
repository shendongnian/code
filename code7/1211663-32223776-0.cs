        [WebMethod]
        public JsonResult testmethod()
        {
            List<YourObject> objectlist = new List<YourObject>();
            JsonResult result = new JsonResult();
            result.Data = objectlist;
            return result;
        }
