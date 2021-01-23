    public class Reload : MonoBehaviour {
      public float ammo;
      public Image progress;
      
      private bool _alreadyReloading;
      private bool _isTimerRunning;
      void Start () {
          _alreadyReloading = false;
          _isTimerRunning = false;
      }
      
      IEnumerator needtimertime(){
          yield return new WaitForSeconds (6.5f);
          _needTimer = false;
      }
      
      IEnumerator uztaisyt(){
          Debug.Log ("REEELOUUUDING!");
          yield return new WaitForSeconds(6.5f);
          ammo += 1;
          _alreadyReloading = false;
      }
      void Update () {
          if (ammo < 5) {
              if(_alreadyReloading == false){                                        
                  StartCoroutine(uztaisyt());
                  _alreadyReloading = true;
                  
                  //this will check for and start the progress bar timer in the same udate call
                  //so both coroutines finish on the same frame update
                  if(!_isTimerRunning){
                    _isTimerRunning = true;
                    timer ("");
                  }
              }
          }
          if (progress.fillAmount <= 0) {
              progress.fillAmount = 1.0f; 
          }
      }
      void timer(string tipas){
          progress.fillAmount -=  Time.deltaTime / 6.5f;
          StartCoroutine (needtimertime ());
      }
    }
