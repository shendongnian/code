    class MyMenu
    {
        public static void AddLine(Form f)
        {
    
            ShapeContainer canvas = new ShapeContainer();
            LineShape theLine = new LineShape();
    
            canvas.Parent = f;
    
            theLine.Parent = canvas;
            theLine.BorderColor = SystemColors.ControlDarkDark;
    
            theLine.StartPoint = new System.Drawing.Point(-3, 154);
            theLine.EndPoint = new System.Drawing.Point(212, 154);
    
        }
    }
