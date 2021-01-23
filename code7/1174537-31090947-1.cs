        class abstract DiagramElement : IDrawable
        {
            public abstract void Draw();   
        }
        
        
        class ClassDiagramElement:DiagramElement 
        {
            public overrides void Draw()
            {
               ElementDrawing elementDrawing = new ClassDrawing();
               elementDrawing.DrawElement(); 
            }
        }
        
        class InterfaceDiagramElement:DiagramElement 
        {
            public overrides void Draw()
            {        
               ElementDrawing elementDrawing = new InterfaceDrawing();
               elementDrawing.DrawElement([maybe need some parameters]); 
            }
        }
