    using UnityEngine;
    using System.Threading;
    
    public class ChessAI : MonoBehaviour
    {
      Thread aiThread;
    
      void StartAI()
      {
        aiThread = new Thread(new ThreadStart(AIThread));
        aiThread.Start();
      }
    
      void AIServer()
      {
        // do stuff here - be careful of accessing data being changed by main thread
      }
    
      public void OnApplicationQuit()
      {
        // It is crucial in the editor that we stop the background thread when we exit play mode
        aiThread.Abort();
      }
    }
