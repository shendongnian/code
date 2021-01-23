    public partial interface ICountyService
    {
        County Get(int id);
        County GetByCompanyCountyID(int id);
        IEnumerable<County> ListOfCounties();
        void Delete(County county);
        IEnumerable<State> ListOfStates();
        void Add(County county);
        County SearchByName(string county);
    }
    public partial class CountyService : ICountyService
    {
        private readonly ICountyRepository _countyRepository;
        public CountyService(ICountyRepository countryRepository)
        {
            _countyRepository = countryRepository;
        }
        /// <summary>
        /// Returns a county
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public County Get(int id)
        {
            return _countyRepository.Get(id);
        }
        /// <summary>
        /// Returns a county by County Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public County GetByCountyID(int id)
        {
            return _countyRepository.GetByMedicaidCountyID(id);
        }
        /// <summary>
        /// Returns all counties
        /// </summary>
        /// <returns></returns>
        public IEnumerable<County> ListOfCounties()
        {
            return _countyRepository.ListOfCounties();
        }
        /// <summary>
        /// Deletes a county
        /// </summary>
        /// <param name="county"></param>
        public void Delete(County county)
        {
            _countyRepository.Delete(county);
        }
        /// <summary>
        /// Return a static list of all U.S. states
        /// </summary>
        /// <returns></returns>
        public IEnumerable<State> ListOfStates()
        {
            var states = ServiceHelpers.CreateStateList(); 
            return states.ToList();
        }
        /// <summary>
        /// Add a county
        /// </summary>
        /// <param name="county"></param>
        public void Add(County county)
        {
            county.CreatedUserID = System.Web.HttpContext.Current.User.Identity.Name;
            county.CreatedDate = DateTime.Now;
            _countyRepository.Add(county);
        }
        /// <summary>
        /// Return a county by searching it's name
        /// </summary>
        /// <param name="county"></param>
        /// <returns></returns>
        public County SearchByName(string county)
        {
            return _countyRepository.SearchByName(county);
        }
    }
