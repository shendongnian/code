        public JsonResult IsCityCodeValid(string CityCode)
        {
            //Do you DB validations here
            if (!cityRepository.IsValidCityCode(cityCode))
            {
                //Invalid
               return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {            
                //Valid
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
