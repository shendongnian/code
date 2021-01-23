    private static void loadFileSystems() {
      synchronized (FileSystem.class) {
        if (!FILE_SYSTEMS_LOADED) {
          ServiceLoader<FileSystem> serviceLoader = ServiceLoader.load(FileSystem.class);
          for (FileSystem fs : serviceLoader) {
            SERVICE_FILE_SYSTEMS.put(fs.getScheme(), fs.getClass());
          }
          FILE_SYSTEMS_LOADED = true;
        }
      }
