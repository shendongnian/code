    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class PolygonButton : MonoBehaviour {
    
        public string param;
    
        public System.Action onClick;
    
        float animSpeed = 1.5f;
        IEnumerator anim;
        bool animating;
        Rect res; 
        Camera mainCam;
        float theWidth = 689;
    
        void Start()
        {
            mainCam = GameObject.FindObjectOfType<Camera>();
            res = mainCam.pixelRect;
            anim = buttonAnimation();
            animating = false;
            GetComponent<LineRenderer>().material.SetColor("_Color", new Color32(255, 255, 0, 0));
    
            LineRenderer lr = GetComponent<LineRenderer>();
            PolygonCollider2D polColliedr = GetComponent<PolygonCollider2D>();
            int i = 0;
            lr.numPositions = polColliedr.points.Length + 1;
            foreach (Vector2 point in polColliedr.points)
            {
                lr.SetPosition(i, point);
                i++;
            }
            lr.SetPosition(i, lr.GetPosition(0));
    
            //change scale for different aspect ratio
           
            float currWidth = GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta.x;
            
            GetComponent<RectTransform>().localScale = new Vector3(currWidth / theWidth, currWidth / theWidth, currWidth / theWidth);
        }
    
        void Update()
        {
            //If resolution changes - we must change button scale
            if(mainCam.pixelRect.height != res.height || mainCam.pixelRect.width != res.width)
            {
                res = mainCam.pixelRect;
    
                float currWidth = GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta.x;
                GetComponent<RectTransform>().localScale = new Vector3(currWidth / theWidth, currWidth / theWidth, currWidth / theWidth);
            }
        }
    
        void OnMouseEnter()
        {
            CoroutineExecutor.instance.Execute(anim);
        }
    
        void OnMouseExit()
        {
            ResetAnim();
        }
    
        void OnMouseUpAsButton()
        {
            ResetAnim();
            if(onClick != null)
                onClick();
        }
    
        void OnDestroy()
        {
            CoroutineExecutor.instance.StopExecution(anim);
        }
        
        void ResetAnim()
        {
            CoroutineExecutor.instance.StopExecution(anim);
            anim = null;
            anim = buttonAnimation();
            GetComponent<LineRenderer>().material.SetColor("_Color", new Color32(255, 255, 0, 0));
            animating = false;
        }
    
        IEnumerator buttonAnimation()
        {
            //Debug.Log("Start animation!");
            if (animating)
                yield break;
            GetComponent<LineRenderer>().material.SetColor("_Color", new Color32(255, 255, 0, 0));
            
            animating = true;
            LineRenderer lr = GetComponent<LineRenderer>();
            while (true)
            {
                float t = 0;
                while(t < 1)
                {
                    t += Time.deltaTime * animSpeed;
                    lr.material.SetColor("_Color", Color.Lerp(new Color32(255, 255, 0, 0), new Color32(255, 255, 0, 255), t));
                    yield return new WaitForEndOfFrame();
                }
                t = 0;
    
                while (t < 1)
                {
                    t += Time.deltaTime * animSpeed;
                    lr.material.SetColor("_Color", Color.Lerp(new Color32(255, 255, 0, 255), new Color32(255, 255, 0, 0), t));
                    yield return new WaitForEndOfFrame();
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
