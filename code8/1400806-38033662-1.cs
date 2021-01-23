    		public ActionResult USeSimpleMathClient()
		{
			return View("Index");
		}
		[HttpPost]
		public ActionResult USeSimpleMathClient(SimpleMathVM viewModel)
		{
			if (viewModel.Num2 == 0 && viewModel.Operation == '÷')
			{
				ModelState.AddModelError(string.Empty, "You can't divide by zero!");
				viewModel.Result = "You can't divide by zero!";
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
