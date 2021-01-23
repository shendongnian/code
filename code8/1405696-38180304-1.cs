    using UnityEngine;
    using System.Collections;
    public class Zoom : MonoBehaviour
    {
	    private float _speed = 10;
	private void Update()
	{
		float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
		if (mouseScroll!=0)
		{
			transform.Translate(Mathf.Sign(mouseScroll) * transform.forward * _speed * Time.deltaTime, Space.World);
		}
	}
    }
