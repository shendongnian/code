    private void button_clicked(object sender, EventArgs e)
    {
       
        string theText = textBox1.Text;
        string pkgLocation;
        Package pkg = null;
        Microsoft.SqlServer.Dts.Runtime.Application app;
        DTSExecResult pkgResults;
        Microsoft.SqlServer.Dts.Runtime.Variables myVars = pkg.Variables;
        pkgLocation =
        @"C:\Users\Visual Studio 2008\Projects" +
        @"\Integration Services Project1\xyz.dtsx";
        app = new Microsoft.SqlServer.Dts.Runtime.Application();
        pkg = app.LoadPackage(pkgLocation, null);
        myVars["Account_number"].Value = theText;
        pkgResults = pkg.Execute(null, myVars,null,null,null);
    }
