    public Builder
    {
        bool _prop = false;
        public Builder WithProperty(bool prop)
        {
            _prop = prop; 
             return this;
        }
        public Widget Build(){ 
            if(prop)
               return new FooWidget();
            else 
               return new BarWidget();
        }   
    }
    public abstract class Widget()
    {
    }
    public class FooWidget: Widget{}
    public class BarWidget: Widget{}
