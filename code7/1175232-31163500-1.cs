    public class UserBLL
    {
        private IValidation _validator;
        private CityRepository _cityRepository;
        public class UserBLL(IValidation validator, CityRepository cityRep)
        {
            _validator = validator;
            _cityRepository = cityRep;
        }
        //other stuff...
        public bool IsCityCodeValid(CityCode cityCode)
        {
            if (!cityRepository.IsValidCityCode(model.CityCode))
            {
                _validator.AddError("Error", "Message.");
            }
            return _validator.IsValid;
        }
    }
