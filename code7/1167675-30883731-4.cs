	public void CreateOrActivateForm<T>() where T : Form
	{
		IEnumerable<T> openForms = Application.OpenForms.OfType<T>();
		if (openForms.Any())
		{
			foreach (T openForm in openForms)
			{
				openForm.Activate();
			}
		}
		else
		{
			Form form = (T)Activator.CreateInstance(typeof(T));
			form.Show();
		}
	}
	public void OpenForm2()
	{
		CreateOrActivateForm<Form2>();
	}
