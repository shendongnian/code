    class YourApp{
       ....
       public void Update(GameTime gameTime, MouseState mouse)
        {
             if([mouse is within the window]){
                burger.Update(...);
                //+most of your updates here
             }else{
                //pause game or just display a warning that mouse is outside of the window
             }
        }
        ...
    }
