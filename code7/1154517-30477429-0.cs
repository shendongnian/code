    public bool Chek(string p) {
      if (p != null) {
        using (Bitmap img = new Bitmap(p)) {
          for (int i = 0; i < img.Width; i++) {
            for (int j = 0; j < img.Height; j++) {
              Color c1 = img.GetPixel(i, j);
              if (c1.R <= c1.B && c1.G <= c1.B) {
                return true;
              }
            }
          }
        }
      }
      return false;
    }
