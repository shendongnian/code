            [HttpPost]
            public ActionResult PriceFunction(decimal param)
            {
                return Json("OK Got the value:" + param.ToString());
            }
