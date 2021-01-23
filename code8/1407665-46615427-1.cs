    public class VenuesController : Controller
    {
        private readonly IViewRender _viewRender;
        public VenuesController(IViewRender viewRender)
        {
            _viewRender = viewRender;
        }
        public async Task<IActionResult> Edit()
        {
            string html = await _viewRender.RenderAsync("Emails/VenuePublished", venue.Name);
            return Ok();
        }
    }
