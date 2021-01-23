    public class SomeCtrlController : Controller
    {
        public PartialViewResult Conversation(int id)
        {
            List<Conversation> conversations = new List<Conversation>();
            //Use id to create your Model and pass it to Partial View
            conversations = PopulateConversations(id);
            // The below code search for Conversation.cshtml inside Views\SomeCtrl folder
            return PartialView(conversations);
        }
    }
