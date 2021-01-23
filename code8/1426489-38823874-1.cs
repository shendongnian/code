        [HttpPost]
        public ActionResult Applay(FilterRule obj)
        {
            var messages = context.messages.BuildQuery(obj).ToList();
            return JsonContent(messages);
        }
