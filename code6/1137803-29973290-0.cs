    /// <summary>
    /// Handles the creation of universal properties and methods
    /// </summary>
    public class BaseController : ApiController
    {
        // Create our public properties
        protected DatabaseContext DbContext { get; private set; }
        protected UserService UserService { get { return Request.GetOwinContext().GetUserManager<UserService>(); } }
        protected RoleService RoleService { get { return Request.GetOwinContext().GetUserManager<RoleService>(); } }
        protected ModelFactory ModelFactory { get { return new ModelFactory(this.Request, this.UserService); } }
        public BaseController()
        {
            this.DbContext = new DatabaseContext();
        }
        
        /// <summary>
        /// Used to return the correct error from an Identity Result
        /// </summary>
        /// <param name="result">The Identity Result to process</param>
        /// <returns></returns>
        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            // If there is no result, return an internal server error
            if (result == null)
                return InternalServerError();
            // If we have an error
            if (!result.Succeeded)
            {
                // If we have some errors
                if (result.Errors != null)
                {
                    // For each error, add to the ModelState
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error);
                }
                // If our ModelState is valid
                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }
                // Return a BadRequest with our ModelState
                return BadRequest(ModelState);
            }
            // Return null if no errors are found
            return null;
        }
    }
