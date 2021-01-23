    [Authorize(Roles = "Admin,SuperUser")]
    public class MyController
    {
        [AllowAnonymous] // All users have access
        public ActionResult Index()
        {
            return View();
        {
        // Only authenticated users in Admin or SuperUser
        // role have access
        public ActionResult Contact()
        {
            return View();
        {
        // Only authenticated users in Admin or SuperUser
        // role have access
        public ActionResult About()
        {
            return View();
        {
    }
