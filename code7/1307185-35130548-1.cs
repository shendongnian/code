    private void OnButtonClick(object sender, EventArgs e)
    {
        // Pass in instance data set / table variables to static method.
        SpecialFunctions.DoSomethingWithInstanceVariable(this.Files, this.MyFile);
    }
