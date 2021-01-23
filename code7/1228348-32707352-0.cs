    void Main()
    {
    	var c = new Crud<Shape>(); //Crud contains a List<Shape>
    	c.Save(new Shape());       //Crud.SavedItems is a List<Shape> with one item
    	
    	ICrud<IShape> broken = ((ICrud<IShape>)c);
    	broken.Save(new AnotherShape()); // Invalid ! 
                                         // Trying to add a 'AnotherShape' to a List<Shape>
    }
    
    public interface IShape {
        string ShapeName {get;}
    }
    
    public interface ICrud<in T> where T: IShape
    {
       void save(T form);
    }
    
    public class Shape : IShape {
    	public string ShapeName { get; set; }
    }
    
    public class AnotherShape : IShape {
    	public string ShapeName { get; set; }
    }
    
    public class Crud<T> : ICrud<T> where T : IShape
    {
    	public List<T> SavedItems  = new List<T>();
    	public void save(T form)
    	{
    		//Do some saving..
    		SavedItems.Add(form);
    	}
    }
