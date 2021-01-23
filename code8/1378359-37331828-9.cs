    public class SomeClassThatNeedCookieServicesController : Controller {
        ICookieService cookieService;
        public SomeClassThatNeedCookieServicesController(ICookieService cookieService) {
            this.cookieService = cookieService;
        }
    }
