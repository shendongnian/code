                using UnityEngine;
                using System.Collections;
                using UnityEngine.UI;
                public class SetTransparancy : MonoBehaviour {
                    public Button myButton;
                    // Use this for initialization
                    void Start () {
                        myButton.image.color = new Color(255f,0f,0f,.5f);
                    }
                    
                    // Update is called once per frame
                    void Update () {
                    
                    }
                }
