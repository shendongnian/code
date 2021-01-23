      [HttpPost]
            public JsonResult GetCityList()
            {
                string text;
                var fileStream = new FileStream(@"E:\NLogErrors\File.Json", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
                List<City> items = JsonConvert.DeserializeObject<List<City>>(text);
                return Json(items);
            }
