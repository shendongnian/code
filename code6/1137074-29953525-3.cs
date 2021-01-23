    using UnityEngine;
    public class GameSaver : MonoBehaviour
    {
        int _score;
   
        void OnEnable()
        {
             _score = PlayerPrefs.GetInt("Player Score");
        }
        void OnDisable()
        {
             PlayerPrefs.SetInt("Player Score", score);
        }
        void Update()
        {
            // change the _score during the game execution.
        }
    }
