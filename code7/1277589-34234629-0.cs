        public class WorldFeatureProperties
        {
            public string Name { get; set; }
            public string Population05 { get; set; }
            public string Region { get; set; }
            public string ISO2 { get; set; }
            public string ISO3 { get; set; }
            public string Area { get; set; }
            public string WorldGeometry { get; set; }
        }
        public ActionResult GetWorldGeometry()
        {
            var worldgeo = (from w in _bdEntities.worlds1 select w);
            var retval = new List<WorldFeatureProperties>();
           
            foreach (var w in worldgeo)
            {
                var currentLocation = JsonConvert.DeserializeObject<WorldFeatureProperties>(w);
                currentLocation.WorldGeometry = WorldGeometry.STGeomFromText(new SqlChars(w.geom.AsText()), 4326).ToGeoJSONGeometry();
                retval.Add(currentLocation);
           }
            var serializedData = JsonConvert.SerializeObject(retval, Formatting.Indented,
                  new JsonSerializerSettings
                  {
                      ContractResolver = new CamelCasePropertyNamesContractResolver(),
                      NullValueHandling = NullValueHandling.Ignore
                  });
            return Json(serializedData, JsonRequestBehavior.AllowGet);
        }
