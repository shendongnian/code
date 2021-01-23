    public interface INode
    {
            List<INode> _TargetObject { get; }
            List<IAttribute> _AttributeObject { get; }
    }  
    public interface IAttribute : INode
    {
    }  
    public class Author : Interfaces.INode
    
    public class CoAuthor : Interfaces.IAttribute 
    {... your class implementation ...}
    public class Venue : Interfaces.IAttribute
    {... your class implementation ...}
    public class Paper : Interfaces.IAttribute
    {... your class implementation ...}
     
