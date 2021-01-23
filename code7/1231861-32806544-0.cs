        [OutputCache(Duration=10, VaryByParam="none")]
        public ActionResult Result()
        {
            return Data();
        }
