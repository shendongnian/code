	public void CreateOrActivateForm<T>() where T : Form
	{
			IEnumerable<T> openForms = Application.OpenForms.OfType<T>();
			if (openForms.Any())
			{
					foreach (T form2 in openForms)
					{
							form2.Activate();
					}
			}
	}
	public void OpenForm2()
	{
		CreateOrActivateForm<Form2>();
	}
