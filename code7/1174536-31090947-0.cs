        class abstract DiagramElement : IDrawable
        {
            public abstract void Draw();   
        }
        
        
        class ClassDiagramElement:DiagramElement 
        {
            public overrides void Draw()
            {
               ElementDrawing elementDrawing = new ClassDrawing();
               elementDrawing.Draw(); 
            }
        }
        
        class InterfaceDiagramElement:DiagramElement 
        {
            public overrides void Draw()
            {
    // ElementDrawing is a base class for all the derived classes that draw the 
    // different elements in your UML.
    
               ElementDrawing elementDrawing = new InterfaceDrawing();
               elementDrawing.Draw([maybe need some parameters]); 
            }
        }
