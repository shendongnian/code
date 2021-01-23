    JsonResult returnObj = new JsonResult
            {
                Data = new
                {
                    wasSuccessful = myBool,
                },
                ContentEncoding = System.Text.Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
            return Json(returnObj);
