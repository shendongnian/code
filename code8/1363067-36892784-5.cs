    using UnityEngine;
    using UnityEngine.EventSystems;
    
    //i chose box collider because its cheap
    [RequireComponent(typeof(BoxCollider))]
    public class RenderTextureRaycaster : MonoBehaviour, IPointerDownHandler {
    
        //assign in inspector
        public Camera portalExit;
    
        BoxCollider portal;
        Vector3 portalExitSize;
        
        void Start() {
            portal = GetComponent<BoxCollider>();
            //this is the target camera resolution, idk if there is another way to get it.
            portalExitSize = new Vector3(portalExit.targetTexture.width, portalExit.targetTexture.height, 0);
        }
    
        public void OnPointerDown(PointerEventData eventData) {
            //the click in world space
            Vector3 worldClick = eventData.pointerCurrentRaycast.worldPosition;
            //transformed into local space
            Vector3 localClick = transform.InverseTransformPoint(worldClick);
            //since the origin of the collider is in its center, we need to offset it by half its size to get it realtive to bottom left
            Vector3 textureClick = localClick + portal.size / 2;
            //now we scale it up by the actual texture size which equals to the "camera resoution"
            Vector3 rayOriginInCameraSpace = Vector3.Scale(textureClick, portalExitSize);
    
            //with this knowledge we can creata a ray.
            Ray portaledRay = portalExit.ScreenPointToRay(rayOriginInCameraSpace );
            RaycastHit raycastHit;
    
            //and cast it.
            if (Physics.Raycast(portaledRay, out raycastHit)) {
                Debug.DrawLine(portaledRay.origin, raycastHit.point, Color.blue, 4);
            }
            else {
                Debug.DrawRay(portaledRay.origin, portaledRay.direction * 100, Color.red, 4);
            }
        }
    }
