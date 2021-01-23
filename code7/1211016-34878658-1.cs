    private void UpdateHead() {
        if (updated) {  // Only one update per frame, please.
          return;
        }
        updated = true;
        Cardboard.SDK.UpdateState();
        if (trackRotation) {
          var rot = Cardboard.SDK.HeadPose.Orientation;
      
          if (Screen.orientation == ScreenOrientation.LandscapeRight) {
            rot = Quaternion.Euler(0, 180, 0) * rot; //           << Workaround
          }
          if (target == null) {
            transform.localRotation = rot;
          } else {
            transform.rotation = target.rotation * rot;
          }
        }
        if (trackPosition) {
          Vector3 pos = Cardboard.SDK.HeadPose.Position;
          if (target == null) {
            transform.localPosition = pos;
          } else {
            transform.position = target.position + target.rotation * pos;
          }
        }
        if (OnHeadUpdated != null) {
          OnHeadUpdated(gameObject);
        }
      }
