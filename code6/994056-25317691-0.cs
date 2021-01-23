    public class MyDraw
    {
    	public MyDraw(IDrawingTool drawingTool)
    	{
    		// Your code here
    	}
    }
    
    kernel.Bind<IDrawingTool>().ToMethod(c => new Brush(5));
    kernel.Bind<IDrawingTool>().ToMethod(c => new Brush(25));
    kernel.Bind<IDrawingTool>().ToMethod(c => new Pencil);
    
    // Runtime exception due to ambiguity: How would the container know which drawing tool to use?
    var md = container.Get<MyDraw>();
 
