    public class ReorganizationVm()
    {
        public List<Schools> SchoolList { get; set; }
    }
    
    
    ReorganizationVm model = new ReorganizationVm(); // an instance of my view model
        public JsonResult Schools(int townCode, int sauId, int fiscalYear)
        {
            using (var service = new ParameterService(this.User))
            {
                try
                {
                    model.Schools = new List<School>();
                    foreach (var o in service.GetSchools(townCode, sauId, fiscalYear))
                    {
                        School School = new School
                        {
                            SchoolId = o.School_ID,
                            SchoolName = o.SchoolName,
                            TownName = o.TownName,
                            isMoving = false
                        };
                        model.Schools.Add(School);
                    }
    
                    return Json(model, JsonRequestBehavior.AllowGet); //pass whole model variable
                }
                catch (Exception ex)
                {
    
                }
                return Json(null);
            }
        }
