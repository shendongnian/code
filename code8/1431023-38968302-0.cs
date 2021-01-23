            public abstract class SvgElement
            {
    	      public abstract List<SvgPath> PathData { get; set;}
            }
    
            public class SvgPath : SvgElement
            {
    	      public override List<SvgPath> PathData { get; set;}	    
            }
    
            public class TestSvg<T> where T:SvgElement
            {
    	 
            }
