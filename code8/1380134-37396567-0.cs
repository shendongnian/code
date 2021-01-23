public static class GameConstants { //no monobehaviour == can be a "proper, global" singleton!
   public static float GetGravity {
      get { return [whatever you want]; }
      //why not Physics.gravity, using locally when and where it's needed?
   }
   //etc, add your methods, properties and such
   //use this approach if and only IF you access these values application wide!
   //otherwise, instead of a """singleton""" logic you just implemented,
   //consider adding an empty GameObject to the Scene, name it "GM" and
   //attach a "GameManager" script to it, having all the methods and
   //properties you'll need Scene-wide! You can also consider
   //using PlayerPrefs (see help link below) instead of a global static
   //class, so you save memory (but will need to "reach out" for the data)
}<br>
private void FixedUpdate() { //FIXED update as you'll work with physics!
//float dTime = Time.time - timeSinceBounce; //not needed
//positioning like this is not recommended, use AddForce or set direction and velocity instead
 ballPosition.x -= meterOffset / sensitivity; 
 ballPosition.y = ballInitialPosition.y + GameConstants.Instance.GetBallYVel ()
 * Time.fixedDeltaTime - 0.5f * GameConstants.Instance.GetGravity () * Time.fixedDeltaTime * Time.fixedDeltaTime; //Yi+Vy*t-0.5(G)(time^2)
 ballPosition.z = (-dTime * GameConstants.Instance.GetBallZVel ()
 + ballInitialPosition.z) * startConstant; //Zi + t*Vz
 ball.transform.position = ballPosition;
}</pre>**BUT** to be honest,
