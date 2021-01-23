      var target = lin
        .Select(line => line.Contains("license=") 
          ? line.Contains("license=false") 
              ? line.Replace("license=false", "license=true")
              : line.Replace("license=", "license=true")
          : line);
    
      File.WriteAllLines(installerfilename, target);
