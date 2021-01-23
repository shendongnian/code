    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyCustomControlDesigner))]
    public class MyCustomControl:Button
    {
    }
    public class MyCustomControlDesigner:ControlDesigner
    {
       protected override void PostFilterProperties(System.Collections.IDictionary properties)
       {
           base.PostFilterProperties(properties);
           properties.Remove("Modifiers");
           properties.Remove("GenerateMember");
       }
    }
