    using TestSolution.Utility;
     ...
    
    public JsonResult getData()
    {
       try
       {
         var stringlist = object.getstrlist();
         return Json(stringlist.ToIdNameList(), JsonRequestBehavior.AllowGet);
       }
       catch (Exception ex)
       {
          return Json("", JsonRequestBehavior.AllowGet);
       }
    }
    
    =============================
    
    using TestSolution.Models;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestSolution.Utility
    {
        /// <summary>
        /// Kendo Drop Down List Extention
        /// </summary>
        public static class KendoDropDownListExtention
        {
            public static List<IdName> ToIdNameList(this string[] stringList)
            {
                return stringList.Select(sl => new IdName() { Name = sl, Value = sl }).ToList();
            }
        }
    }
