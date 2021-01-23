        [HttpGet]
        public ActionResult GetJsonData()
        {
            var data = new
            {
                title = "T1",
                data = new[]
                {
                    new
                    {
                        value = "V1",
                        key = "K1"
                    },
                    new
                    {
                        value = "V2",
                        key = "K2"
                    }
                }
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
