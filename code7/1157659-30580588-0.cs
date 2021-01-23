      public class LikelyToReturnModel
      {
         [Required]
         public int LikelyToReturn { get; set; }
      }
      public class RecomendToFriendModel
      {
         public int LikelyToReturn { get; set; }
         [Required]
         public int RecomendToFriend { get; set; }
      }
      public class PatientSatisfactionController : Controller
      {
         //
         // GET: /PatientSatisfaction/
         public ActionResult LikelyToReturn()
         {
            return View(new LikelyToReturnModel());
         }
         [HttpPost]
         [ValidateAntiForgeryToken()]
         public ActionResult LikelyToReturn(LikelyToReturnModel model)
         {
            //validation example
            if (model.LikelyToReturn == 0)
            {
               ModelState.AddModelError("", "Can't be zero!!!");
            }
            if (ModelState.IsValid)
            {
               return RedirectToAction("RecomendToFriend", new { LikelyToReturn = model.LikelyToReturn });
            }
            return View(model);
         }
         public ActionResult RecomendToFriend(int LikelyToReturn)
         {
            return View(new RecomendToFriendModel { LikelyToReturn = LikelyToReturn });
         }
         [HttpPost]
         [ValidateAntiForgeryToken()]
         public ActionResult RecomendToFriend(RecomendToFriendModel model)
         {
            if (ModelState.IsValid)
            {
               //do something
            }
            return View(model);
         }
      }
