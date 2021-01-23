    // Folder x
    for (int x = 2; x <= 7; x++) {
       string xAsString = x.ToString();
       // Folder y
       for (int y = 0; y < 80; y++) {
           string destFolderPath = Path.Combine(folder, xAsString, y.ToString());
           //File z
           for (int z = 0; z <= 70; z++) {
               // File, increment
               i++;
               string filePath = Path.Combine(destFolderPath, z.ToString() + ".png");
               // ...
           }
       }
    }
