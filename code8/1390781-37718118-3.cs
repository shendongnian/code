        public static string GetVo()
        {
            try
            {
                TrackDataEntities1 DB = new TrackDataEntities1();
                var result = DB.tblVeh.Where(x => x.MID.Equals("23065") && x.Name != "")
                      .GroupBy(x => x.Name)
                      .Select(x => "['" + x.Key + "," + x.Count(y => y.Name != "") + "']")
                      .ToList();
                return String.Join(',', result);
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }
