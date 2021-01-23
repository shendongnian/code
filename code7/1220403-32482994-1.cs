        private static void MoveCopy(String source, String target) {
          // assuming that target directory exists
    
          if (!File.Exists(target))
            File.Copy(source, target);
          else
            for (int i = 1; ; ++i) {
              String name = Path.Combine(
                Path.GetDirectoryName(target),
                Path.GetFileNameWithoutExtension(target) + String.Format("(copy{0})", i) +
                Path.GetExtension(target));
    
              if (!File.Exists(name)) {
                File.Copy(source, name);
    
                break;
              }
            }
        }
    
    ...
    
      MoveCopy(filename, temp_file);
