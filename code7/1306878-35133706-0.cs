     public JsonResult GetAllProperties()
        {
            List<Temp> obj = new List<Temp>();
            obj.Add(new Temp("A",1));
            obj.Add(new Temp("B",2));
            obj.Add(new Temp("C",3));
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class Temp
        {
            public string name { get; set; }
            public int empid { get; set; }
            public Temp(string n, int id)
            {
                name = n;
                empid = id;
            }
           
        }
