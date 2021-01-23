    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using System.Collections.Generic;
    public class UImageRayCast : MonoBehaviour
    {
    Image image;
    Color colorOn, colorOff;
    void Start()
    {
        this.image = this.GetComponent<Image>();
        this.colorOff = this.image.color;
        this.colorOn = new Color(this.colorOff.r, this.colorOff.g, this.colorOff.b, this.colorOff.a * 0.5f);
    }
    void Update()
    {
        this.image.color = this.colorOff;
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        List<RaycastResult> raycastResult = new List<RaycastResult>();
        foreach (Touch touch in Input.touches)
        {
            pointer.position = touch.position;
            EventSystem.current.RaycastAll(pointer, raycastResult);
            foreach (RaycastResult result in raycastResult)
            {
                if (result.gameObject == this.gameObject)
                {
                    if(touch.phase == TouchPhase.Began)
                    {
                        Debug.Log("Began " + result.gameObject.name );
                    }
                    else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        this.image.color = this.colorOn;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        Debug.Log("End  " + result.gameObject.name);
                    }
                    //this.gameObject.transform.position = touch.position;
                    //Do Stuff
                }
            }
            raycastResult.Clear();
        }
    }
