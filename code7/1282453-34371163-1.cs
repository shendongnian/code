    public interface IChildItem                                              
    { }                                                                      
                                                                             
    public interface IItem<out TChild> where TChild : IChildItem             
    {                                                                        
        IEnumerable<TChild> Children { get; }                                
    }                                                                        
                                                                             
    public class ChildItem1 : IChildItem                                     
    { }                                                                      
                                                                             
    public class ChildItem2 : IChildItem                                     
    { }                                                                      
                                                                             
    public class Item1 : IItem<ChildItem1>                                   
    {                                                                        
        public IEnumerable<ChildItem1> Children                              
        {                                                                    
            get { return null; }                                             
        }                                                                    
    }                                                                        
                                                                             
    public class Item2 : IItem<ChildItem2>                                   
    {                                                                        
        public IEnumerable<ChildItem2> Children                              
        {                                                                    
            get { return null; }                                             
        }                                                                    
    }                                                                        
                                                                             
    IItem<ChildItem1> variable = new Item1();                                
    IItem<IChildItem> variable2 = variable;                                
