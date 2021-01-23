    public partial class BaseUserControl :  DotNetNuke.Entities.Modules.PortalModuleBase
    {
    // basicly this will fix the localization issue 
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string FileName =  System.IO.Path.GetFileNameWithoutExtension(this.AppRelativeVirtualPath);
        if (this.ID != null)
            //this will fix it when its placed as a ChildUserControl 
            this.LocalResourceFile = this.LocalResourceFile.Replace(this.ID, FileName);
        else
            // this will fix it when its dynamically loaded using LoadControl method 
            this.LocalResourceFile = this.LocalResourceFile + FileName + ".ascx.resx";
    }
    }
