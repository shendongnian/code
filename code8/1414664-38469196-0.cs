    public class MyGame : Game {
       bool manualTick;
       int manualTickCount = 0;
       Timer mTimer;
       public MyGame() {
          mTimer = new Timer {
             Interval = (int)(TargetElapsedTime.TotalMilliseconds)
          };
          mTimer.Elapsed += (s, e) => {
             if (manualTickCount > 2) {
                manualTick = true;
                Debug.Print("manual tick");
                Tick();
                manualTick = false;
             }
             manualTickCount++;
          };
         
          // required to prevent exception on exit
          // otherwise the timer keeps running after the window closes
          Exiting += (s, e) => mTimer.Dispose();
          // it might be needed to do something similar in the Dispose event
          // if the game can be disposed without exiting
       }
       // the constructor is too early to start the timer, so put it in initialize
       protected override void Initialize() {
          mTimer.Start();
          base.Initialize();
       }
       // and lastly, in Update
       protected override void Update(GameTime pGameTime) {
          if (!manualTick) {
             manualTickCount = 0;
             Debug.Print("not manual");
          }
          base.Update(pGameTime);
       }
       
       
