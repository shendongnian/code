        [System.Web.Mvc.HttpPost]
        public JsonResult SyncPush(BlockList content)
        {
            try
            {
                if (content != null)
                {
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                return Json("failed due to null", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("failed " + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
