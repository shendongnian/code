		protected override bool OnBackButtonPressed()
		{
			foreach (Page page in Navigation.ModalStack)
			{
				page.Navigation.PopModalAsync();
			}
			return true;
		}
