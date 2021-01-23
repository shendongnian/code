    public class SimObject
    {
        //.........Rest properties
         
        public virtual char DrawChar { get{return '*';}}
    
        public virtual void Draw() 
        {            
            //.....rest code
            Console.Write(DrawChar);
        }
    }
    
    public class Plant : SimObject
    {
        //.........Rest properties
        public override char DrawChar { get { return '^'; } }
    
        public void SomeFunction()
        {
            base.Draw();//will print out '^' in end
        }
    }
    
    public class Caterpillar : SimObject
    {
        //.........Rest properties
        public override char DrawChar { get { return '-'; } }
    
        public void SomeFunction()
        {
            base.Draw();//will print out '-' in end
        }
    }
    
    public class SomeOtherClass : SimObject
    {
        //.........Rest properties       
    
        public void SomeFunction()
        {
            base.Draw();//will print out '*' in end
        }
    }
