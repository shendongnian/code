    public abstract class Base
    {
        public virtual void SetPropertiesFromXml(XElement node) 
        { 
            //<Set Properties like: this.Property = node.Element("key");>
        }
    }
    public class Base1
    {
        public override void SetPropertiesFromXml(XElement node)
        {
            //<Set Custom Properties for Base1>
            
            //Call Base to add the normal properties as well
            base.SetPropertiesFromXml(node);
        }
    }
