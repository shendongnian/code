    //Add reference to  System.Drawing.dll then using
    using System.Drawing.Design;
    public class MyButtonToolBoxItem:ToolboxItem
    {
        protected override IComponent[] CreateComponentsCore(IDesignerHost host,
            System.Collections.IDictionary defaultValues)
        {
            if(defaultValues.Contains("Parent"))
            {
                var parent = defaultValues["Parent"] as Control;
                if(parent!=null && parent is Form)
                    return base.CreateComponentsCore(host, defaultValues);
            }
            return null;
        }
    }
