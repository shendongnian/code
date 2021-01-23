    public void Update(GameTime gameTime, MouseState mouse)
    {
        // burger should only respond to input if it still has health
        // move burger using mouse
        if (health > 0)
        {
            //**Simple version**
            //if mouse is within borders, continue with position update.
            if(mouse.X > 0 && mouse.X < windowWidth && mouse.Y > 0 && mouse.Y < windowHeight){
               drawRectangle.X = mouse.X;
               drawRectangle.Y = mouse.Y;
            }else{
               //stuff to do if it it's not updating   
            }
            //**a little different (better) version that should trace walls**
            if(mouse.X < 0){
               drawRectangle.X = 0;
            }else if(mouse.X + drawRectangle.width > windowWidth){ //if I made no mistakes it should subtract the size of the picture and trace the inside border if mouse is outside
               drawRectangle.X = windowWidth - drawRectangle.width;
            }else{
               drawRectangle.X = mouse.X
            }
            if(mouse.Y < 0){
               drawRectangle.Y = 0;
            }else if(mouse.Y + drawRectangle.height > windowHeight ){
               drawRectangle.Y = windowHeight- drawRectangle.height;
            }else{
               drawRectangle.Y = mouse.Y
            }
        }
    }
