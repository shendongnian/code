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
			SchoolEntities schoolEntity = new SchoolEntities();  
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
		}
