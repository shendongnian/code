            // Itterate subdirectories of the live folder
            foreach (var subDir in Directory.GetDirectories(@"C:\test\AB_Systems\ELEGANCE\CB-DOC\live"))
            {
                // Check if path to extobjects exists
                var extObjects = Path.Combine(subDir, "extobjects");
                if (Directory.Exists(extObjects))
                {
                    var pdfFiles = Directory.GetFiles(extObjects, "*").Where(x=>x.EndsWith(".pdf"));
                    // Do something with the pdf file paths
                }
            }
