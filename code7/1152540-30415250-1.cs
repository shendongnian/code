    using UnityEngine;
    using System.Collections;
    public class RightButton : MonoBehaviour {
    
        public Texture bgTexture;
        public Texture airBarTexture;
        public int iconWidth = 32;
        public Vector2 airOffset = new Vector2(10, 10);
    
    
        void start(){
        }
    
        void OnGUI(){
            int percent = 100;
    
            DrawMeter (airOffset.x, airOffset.y, airBarTexture, bgTexture, percent);
        }
    
        void DrawMeter(float x, float y, Texture texture, Texture background, float percent){
            var bgW = background.width;
            var bgH = background.height;
    
            if (GUI.Button (new Rect (x, y, bgW, bgH), background)){
                // Handle button click event here
            }
    
            var nW = ((bgW - iconWidth) * percent) + iconWidth;
    
            GUI.BeginGroup (new Rect (x, y, nW, bgH));
            GUI.DrawTexture (new Rect (0, 0, bgW, bgH), texture);
            GUI.EndGroup ();
        }
    }
