        public static void Main ()
        {
            var myClock = new Clock ();
            //Open the game window
            SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen ();
            myClock.SetClock ();                  //Set clock should be called from here.
            //Run the game loop
            while (false == SwinGame.WindowCloseRequested ()) {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents ();
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen (Color.White);
                SwinGame.DrawFramerate (0, 0);
                myClock.DrawClock ();
                
                if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
                    myClock.UpdateClock ();
                }
                if (SwinGame.MouseClicked (MouseButton.RightButton)) {
                    myClock.ResetClock ();
                }
                //Draw onto the screen
                SwinGame.RefreshScreen (60);
            }
        }
