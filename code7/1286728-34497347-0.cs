    foreach (string path in Directory.GetDirectories(@"C:\", "*.*", SearchOption.AllDirectories)) {
                try { 
                    Console.WriteLine(path);
                } catch (Exception ex) {
                    Console.WriteLine("Unable to access directories in path: " + path);
                }
            }
