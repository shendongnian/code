           var lin = File.ReadLines(Path.Combine(path,"installer.ini")).ToArray();
           var license = lin.Select(line =>
           {
               line = Regex.Replace(line, @"license=.*", "license=yes");
               //you can simply add here more regex replacements
               //line = Regex.Replace(line, @"somethingElse=.*", "somethingElse=yes");
               return Regex.Replace(line, @"lmgr_files=.*", "lmgr_files=true");
           });
           File.WriteAllLines(installerfilename, license);
