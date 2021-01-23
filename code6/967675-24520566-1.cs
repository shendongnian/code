    public PowerTool
    {
         IColor color;
         IShape shape;
         
         public PowerTool(IColor c, IShape s) {
             color = c; share = s;
         }
         void Execute()  {
             color.DoColor();
             shape.DoShape();
         }
    }
