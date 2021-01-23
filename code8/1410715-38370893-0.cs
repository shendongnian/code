        public static void Main()
        {
            JObject jObject = JObject.Parse(Json);
            IEnumerable<EntityParent> parents =
                from parent in jObject["Parents"]
                join child in jObject["Children"] on parent["EntityChild"] equals child["Id"]
                select
                    new EntityParent(
                        parent["Id"].ToString(),
                        new EntityChild(
                            child["Id"].ToString(),
                            child["Age"].ToObject<int>()));
        }
