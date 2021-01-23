	public class Events : Controller 
	{
		public ActionResult Register(int id)
		{
			Event event = DbSource.FindEventById(id);
				
			RegistrationViewModel model = new RegistrationViewModel 
			{
				EventName = event.Name
			}
			
			return this.View(model);
		}
	
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegistrationViewModel model)
		{
			if( ! ModelState.IsValid ) 
			{
				return this.View(model);
			}
			
			// ship the tickets, return thank you view, etc...
		}
	}
	
