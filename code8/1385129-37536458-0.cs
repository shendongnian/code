    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag  ==  "Bricks") {
           #if UNITY_EDITOR
           UnityEditor.EditorApplication.isPlaying = false;
           #else
           Application.Quit();
           #endif
         }
       }
    }
