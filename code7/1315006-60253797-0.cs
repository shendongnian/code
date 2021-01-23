c#
using UnityEngine;
using UnityEngine.SceneManagement ; 
public class next_level : MonoBehaviour
{
    public void next_levl(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 ) ; 
    }
}
