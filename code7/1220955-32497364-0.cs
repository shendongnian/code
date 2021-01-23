        public async Task<JsonResult> GetData(Batch arr)
        {
            try
            {
                return DoTask().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        private async Task<JsonResult> DoTask()
        {
            var success = false;
            var t = await Task.Run(() =>
            {
                //i am Performing long running task here
                success = true;
                return Json(success, JsonRequestBehavior.AllowGet);
            });
            return t;
        }
