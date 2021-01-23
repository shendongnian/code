	using System.Linq;
	using UnityEngine;
	public class Test : MonoBehaviour
	{
		void Update()
		{
			Camera cam = GetComponent<Camera>();
			Ray[] rays = new[]
			{
				new Vector3(0, 0),
				new Vector3(0, cam.pixelHeight),
				new Vector3(cam.pixelWidth, 0),
				new Vector3(cam.pixelWidth, cam.pixelHeight)
			}.Select(ray => cam.ScreenPointToRay(ray)).ToArray();
			Plane xz = new Plane(new Vector3(0, 1, 0), Vector3.zero);
			foreach (Ray ray in rays)
			{
				float distanceAlongRay;
				if (xz.Raycast(ray, out distanceAlongRay))
				{
					Vector3 intersect = ray.GetPoint(distanceAlongRay);
					Debug.DrawLine(transform.position, intersect, Color.red);
				}
			}
		}
	}
