    if (Application.OpenForms.Cast<Form>().Any(form => form.Name == "<YOUR_CHILD_FORM_NAME>"))
    {
    	Form tempForm = Application.OpenForms.Cast<Form>().FirstOrDefault(form => form.Name == "<YOUR_CHILD_FORM_NAME>");
    	if (tempForm.WindowState == FormWindowState.Minimized)
    	{
    		// FORM IS OPEN AND ALSO IN MINIMIZE MODE
    	}
    	else
    	{
    		// FORM IS OPEN BUT NOT IN MINIMIZE MODE
    	}
    }
    else
    {
    	// FORM IS NOT OPEN
    }
