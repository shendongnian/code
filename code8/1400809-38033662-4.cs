    	public ActionResult USeSimpleMathClient()
		{
			return View("Index");
		}
		[HttpPost]
		public ActionResult USeSimpleMathClient(SimpleMathVM viewModel)
		{
        //I moved the checking for zero up here, that way you could immediately return the view. 
        //I kept your version where you populate the Result textbox with the error message,
        //but really you should probably only add the error message to the ModelState.
			if (viewModel.Num2 == 0 && viewModel.Operation == '÷')
			{
				ModelState.AddModelError(string.Empty, "You can't divide by zero!");
				viewModel.Result = "You can't divide by zero!";
            //You can pick which one of the above two lines work better for you.
            //Usually adding error messages to the ModelState is the way to go.
			}
			if (!ModelState.IsValid)
			{
				return View("Index", viewModel);
			}
			switch (viewModel.Operation)
			{
				case '+':
					viewModel.Result = mathClient.Add(viewModel.Num1, viewModel.Num2).ToString();
					break;
				case '-':
					viewModel.Result = mathClient.Subtract(viewModel.Num1, viewModel.Num2).ToString();
					break;
				case '*':
					viewModel.Result = mathClient.Multiply(viewModel.Num1, viewModel.Num2).ToString();
					break;
				case '÷':
					viewModel.Result = mathClient.Divide(viewModel.Num1, viewModel.Num2).ToString();
					break;
				default:
					break;
			}
			return View("Index", viewModel);
		}
