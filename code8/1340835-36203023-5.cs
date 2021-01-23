    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Web;  
    using System.Web.Mvc;  
    using MvcDemoApplication.Models;  
      
    namespace MvcDemoApplication.Controllers  
    {  
        public class DropDownListController : Controller  
        {  
            //  
            // GET: /DropDownList/  
            SchoolEntities1 schoolEntity = new SchoolEntities1();  
            public ActionResult Index()  
            {  
                List<SelectListItem> stateNames = new List<SelectListItem>();  
                StudentModel stuModel=new StudentModel();  
                  
                List<StateMaster> states = schoolEntity.StateMasters.ToList();  
                states.ForEach(x =>  
                    {  
    stateNames.Add(new SelectListItem { Text = x.StateName , Value = x.StateId.ToString() });  
                    });  
                stuModel.StateNames = stateNames;  
                return View(stuModel);  
            }  
      
            [HttpPost]  
            public ActionResult GetDistrict(string stateId)  
            {  
                int statId;  
                List<SelectListItem> districtNames = new List<SelectListItem>();  
                if (!string.IsNullOrEmpty(stateId))  
                {  
                    statId = Convert.ToInt32(stateId);  
    List<DistrictMaster> districts = schoolEntity.DistrictMasters.Where(x => x.StateId == statId).ToList();  
                    districts.ForEach(x =>  
                    {  
    districtNames.Add(new SelectListItem { Text = x.DistrictName, Value = x.DistrictId.ToString() });  
                    });  
                }  
                return Json(districtNames, JsonRequestBehavior.AllowGet);  
            }  
      
        }  
    }
