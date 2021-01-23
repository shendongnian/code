    public abstract class BaseController: ApiController
    {
        private readonly object _lock = new object();
        /// <summary>
        /// The customer this controller is referencing to.
        /// </summary>
        protected Guid CustomerId
        {
            get
            {
                if (!_customerId.HasValue)
                {
                    InitApi();
                    lock (_lock)
                    {
                        if (User.Identity.IsAuthenticated)
                        {
                            Guid? customerId = HttpContext.Current.Cache["APIID" + User.Identity.Name] as Guid?;
                            if (customerId.HasValue)
                            {
                                CustomerId = customerId.Value;
                            }
                            else
                            {
                                UserProfile user = UserManager.FindByName(User.Identity.Name);
                                if (user != null)
                                {
                                    CustomerId = user.CustomerId;
                                    HttpContext.Current.Cache["APIID" + User.Identity.Name] = user.CustomerId;
                                }
                            }
                        }
                        else
                        {
                            _customerId = Guid.Empty;
                        }
                    }
                }
                return _customerId.GetValueOrDefault();
            }
            private set { _customerId = value; }
        }
    // ... more code
    }
