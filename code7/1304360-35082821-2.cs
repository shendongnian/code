    public class DKMenuController : ApiController
    {
        #region Private variable.
        private readonly ITokenService _tokenService;
        private readonly IDKMenuService _dkMenuService;
        private readonly IUserService _userservice;
        private const string Token = "Token";
        #endregion
        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize DKMenu service instance
        /// </summary>
        public DKMenuController(ITokenService tokenService, IUserService userservice, IDKMenuService dkMenuService)
        {
            _tokenService = tokenService;
            _dkMenuService = dkMenuService;
            _userservice = userservice;
        }
