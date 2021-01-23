		[HttpPost]
		public ActionResult PostMessage(string messageText)
		{
			string result;
			try
			{
				// mail.Send() here
				// can use SendAsync but then need to handle result feedback via JavaScript
				result = "Email was sent";
			}
			catch
			{
				result = "Sending Email Failed";
			}
			return View("PostConfirmation", result);
		}
