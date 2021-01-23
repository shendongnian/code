    public interface INode
    {
            List<INode> _TargetObject { get; }
            List<IAttribute> _AttributeObject { get; }
    }  
    public interface IAttribute : INode
    {
    }  
    public class Author : Interfaces.INode
    {
         private List<INode> _targetList ;
         private List<IAttribute> _attributeObject ;
         public Author()
         {
             _targetList = new List<INode>();
         }
         //implementazion of _TargetObject INode method
         public List<INode> _TargetObject 
         { 
             get  
             {
                 return _targetList;
             }
         }
         //implementazion of _AttributeObject INode method
         public List<IAttribute> _AttributeObject 
         { 
             get  
             {
                 return _attributeObject ;
             }
         }
    } 
    
    public class CoAuthor : Interfaces.IAttribute 
    {... your class implementation ...}
    public class Venue : Interfaces.IAttribute
    {... your class implementation ...}
    public class Paper : Interfaces.IAttribute
    {... your class implementation ...}
     
