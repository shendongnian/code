    [HttpGet]
        public JsonResult Get()
        {
            var result = Mapper.Map<IEnumerable<CategoryViewModel>>(_repo.GetAllForUser("lucas@test.com"));
            return Json(result);
        }
