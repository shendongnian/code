    public static CanvasFontFace FindFontFace() {
      // Very hacky . . . there has to be a better way . . .
      CanvasFontFace r = null;
      CanvasFontSet set = CanvasFontSet.GetSystemFontSet();
      string fontFaceName = "Regular"; // change to your face . . .
      string familyName = "Segoe UI"; // change to your family . . . 
      IReadOnlyList<CanvasFontFace> allFaces = set.Fonts;
      string key = "en-us";
      foreach (CanvasFontFace face in allFaces) {
        IReadOnlyDictionary<string, string> faceNames = face.FaceNames;
        IReadOnlyDictionary<string, string> familyNames = face.FamilyNames;
        if (faceNames.ContainsKey(key)) {
          if (familyNames.ContainsKey(key)) {
            if (faceNames[key] == fontFaceName) {
              if (familyNames[key] == familyName) {
                r = face;
                break;
              }
            }
          }
        }
      }
      // if r is null, you probably have an incorrect face name or family name.
      return r;
    }
