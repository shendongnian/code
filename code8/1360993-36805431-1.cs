        public string GetData()
        {
            var data = new Models.BadgeVoleModel();
            data.BadgeList = db.Badges.ToList();
            data.VoleTypeList = db.VoleTypes.ToList();
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return result;
        }
