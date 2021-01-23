    modelState = actionContext.ModelState;
    modelState.ForEach(x =>
			{
				var state = x.Value;
				if (state.Errors.Any())
				{
					foreach (var error in state.Errors)
					{
						<work your magic>
					}
				}
			});
