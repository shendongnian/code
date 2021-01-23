        [HttpPost]
        public ActionResult SaveRule(ExpandoObject ruleObj, string ruleType)
        {
            Type type = GetTypeFromName(ruleType); //uses Assembly.GetType
            var instance = Activator.CreateInstance(type);
            foreach (var prop in type.GetProperties())
            {
                var p = ruleObj.GetType().GetProperty(prop.Name);
                var val = p != null ? p.GetValue(ruleObj, null) : null;
                prop.SetValue(instance, val, null);
            }
            var serialiser = new XmlSerializer(type); 
            var sb = new StringBuilder();
            serialiser.Serialize(new StringWriter(sb), instance);
            return new JsonResult(); //ignore this for purposes of this question
        }
