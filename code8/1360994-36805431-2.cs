        public Models.BadgeVoleModel DeserializeData(string data)
        {
            var result = Newtonsoft.Json.JsonConvert
                        .DeserializeObject<Models.BadgeVoleModel>(data);
            return result;
        }
