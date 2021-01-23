    protected void Step02SubmitButton_Click(object sender, EventArgs e)
    {
         myfunction();
    }           
    
    protected void Step02PreviousButton_Click(object sender, EventArgs e)
    {
         myfunction();
    }
    
    protected void myfunction()
    {
        Session["Step02AllServices"] = Step02AllServices.Checked;
         Session["Step02ContentUploading"] = Step02ContentUploading.Checked;
         Session["Step02ContentLayoutChecking"] = Step02ContentLayoutChecking.Checked;
         Session["Step02TestingVariousBrowsers"] = Step02TestingVariousBrowsers.Checked;
         Session["Step02TestingFunctionality"] = Step02TestingFunctionality.Checked;
         Session["Step02ResponsiveLayouting"] = Step02ResponsiveLayouting.Checked;
         Session["Step02ResponsiveTesting"] = Step02ResponsiveTesting.Checked;
    }
