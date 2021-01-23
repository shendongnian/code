    public class LoggedInComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(HttpContext.Request.Cookies.Get("Bearer"));
        }
    }
