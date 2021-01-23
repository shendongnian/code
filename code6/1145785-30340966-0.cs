    void OnFlick(object sender, System.EventArgs e)
    {
        var gesture = sender as FlickGesture;
        float distanceFromCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 wp1 = new Vector3(gesture.PreviousScreenPosition.x, gesture.PreviousScreenPosition.y, distanceFromCamera);
        wp1 = Camera.main.ScreenToWorldPoint(wp1);
        Vector3 wp2 = new Vector3(gesture.ScreenPosition.x, gesture.ScreenPosition.y, distanceFromCamera);
        wp2 = Camera.main.ScreenToWorldPoint(wp2);
        Vector3 velocity = (wp2 - wp1) / gesture.FlickTime;
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }
