    public class LayoutController : Controller
    {
      /* snip */
    
      // Hard-coded values should be const
      const String AvatarDefaultImage = "avatar1.jpg";
    
      [ChildActionOnly]
      public PartialViewResult Avatar()
      {
        var forumUserState = stateRepository.GetForumUserState();
        if (!String.IsNullOrEmpty(forumUserState.AvatarFileName))
        {
          // Pass off the URL as the model
          return PartialView(model: forumUserState.AvatarFileName);
        }
        // default fallback
        return PartialView(model: AvatarDefaultImage);
      }
    }
