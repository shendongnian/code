    // Generate palette synchronously and return it
    public Palette createPaletteSync(Bitmap bitmap) {
      Palette p = Palette.from(bitmap).generate();
      return p;
    }
    
    // Generate palette asynchronously and use it on a different
    // thread using onGenerated()
    public void createPaletteAsync(Bitmap bitmap) {
      Palette.from(bitmap).generate(new PaletteAsyncListener() {
        public void onGenerated(Palette p) {
          // Use generated instance
        }
      });
    }
