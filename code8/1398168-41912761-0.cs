    private void UpdateHead() {
        if (updated) {  // Only one update per frame, please.
          return;
        }
        updated = true;
        GvrViewer.Instance.UpdateState();
    
        if (trackRotation) {
          var rot = GvrViewer.Instance.HeadPose.Orientation ;
          var rotx = rot.x;
          var roty = rot.y;
          var rotz = rot.z;
          var rotFinal = Quaternion.Euler(rotx*1.15f, roty*1.15f, rotz*1.15f);
          if (target == null) {
            transform.localRotation = rotFinal;
          } else {
            transform.rotation = target.rotation * rotFinal;
          }
        }
    
        if (trackPosition) {
          Vector3 pos = GvrViewer.Instance.HeadPose.Position;
          if (target == null) {
            transform.localPosition = pos;
          } else {
            transform.position = target.position + target.rotation * pos;
          }
        }
    
        if (OnHeadUpdated != null) {
          OnHeadUpdated(gameObject);
        }
      
