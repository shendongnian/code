    [WebMethod]
        public static string GetVoiliations(string id = null)
        {
            try
            {
            T1 DB = new T1();
            string data = "[";
           var re = (from ve in table1 i
                      where !(ve .VName == "")
                      //add new filter
                      && (id == null || ve.Id == id)
                      group ve by ve .VName into g
                      select new
                      {
                          Name = g.Key,
                          cnt = g.Select(t => t.Name).Count()
                      }).ToList();
            data += re.ToList().Select(x => "['" + x.Name + "'," + x.cnt + "]")
              .Aggregate((a, b) => a + "," + b);
            data += "]";
            return data;
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }
