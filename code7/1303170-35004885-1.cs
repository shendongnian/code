    namespace NodeDemo
    {
        public class ColorAttribute : Attribute
        {
            public string Color {get;set;}
            public ColorAttribute(string color)
            {
                Color = color;
            }
        }
        [NodeAttribute("DemoNode")]
        [ColorAttribute("Red")] 
        public class DemoNode
        {
          ... 
        } 
    } 
