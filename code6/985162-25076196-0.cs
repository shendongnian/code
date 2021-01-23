    public class AddressViewChannelModel
    {
        ....
        [Display(Name = "CountryID")]
        public Guid? countryID  { get; set; }
        [Required]
        [Remote("ValidateZipCode", "Address", AdditionalFields = "countryID")]
        [Display(Name = "Zip")]
        public string zip { get; set; }
    }
    public class AddressController : Controller
    {
      ...
        public JsonResult ValidateZipCode(string zip, string countryID)
        {
            ValidationRequest request = new ValidationRequest();
            request.CountryID = Guid.Parse(countryID);
            request.Zip = zip;
            ValidationResponse response = new ValidationResponse();
            response = _addressApi.ZipValidation(request);
            if(response.IsSuccessful == false)
            {
                return Json("Not a valid zip code for your chosen country!"),  JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
