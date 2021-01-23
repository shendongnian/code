    using UnityEngine;
    using System.Collections.Generic;
    public class MyCameraUtilityScript : MonoBehaviour
    {
        public List<Vector3> GetCameraFrustrumCorners()
        {
            List<Vector3> corners = new List<Vector3>(8); // 8 corners
            Camera c = GetComponent<Camera>();
            // corners counterclockwise at near clip plane
            corners.Add(c.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, c.nearClipPlane))); // bottom-left
            corners.Add(c.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, c.nearClipPlane))); // bottom-right
            corners.Add(c.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, c.nearClipPlane))); // top-right
            corners.Add(c.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, c.nearClipPlane))); // top-left
            // corners counterclockwise at far clip plane
            corners.Add(c.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, c.farClipPlane))); // bottom-left
            corners.Add(c.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, c.farClipPlane))); // bottom-right
            corners.Add(c.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, c.farClipPlane))); // top-right
            corners.Add(c.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, c.farClipPlane))); // top-left
            return corners;
        }
    }
