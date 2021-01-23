    public class DemoController : Controller
    {       
         public async Task<IActionResult> Action()
         {
             var model = await _someService.GetPreciousData();
             return Ok(model);
         }
     }
