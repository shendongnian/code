    using UnityEngine;
    using System.Collections;
    public class Paddle : MonoBehaviour {
    
        public Texture texture;
    
        public void Update () {
    
            Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y , 0f);
    
            float mousePosInBlocks = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    
            paddlePos.x = Mathf.Clamp(mousePosInBlocks, leftValue, rightValue);
    
            this.transform.position = paddlePos;
        }
    }
