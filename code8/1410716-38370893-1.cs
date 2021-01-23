        public static void Main()
        {
            JObject jObject = JObject.Parse(Json);
            var children =
                JsonConvert.DeserializeObject<List<EntityChild>>(jObject["Children"].ToString());
            IEnumerable<EntityParent> parents =
                from parent in jObject["Parents"]
                join child in children on parent["EntityChild"] equals child.Id
                select new EntityParent(parent["Id"].ToString(), child);
        }
