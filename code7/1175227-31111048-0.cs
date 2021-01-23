        public JsonResult IsCityCodeValid(string cityCode)
        {
            //Do you DB validations here
            if (!cityRepository.IsValidCityCode(cityCode))
            {
                //Invalid
                Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //Valid
                Json(true, JsonRequestBehavior.AllowGet);
            }
        }
