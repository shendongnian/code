    // Use Path.Combine() to combine path parts.
    var lin = File.ReadLines(Path.Combine(path, "installer.ini")).ToArray();
    // Replace the license=... part. License will now hold the edited file.
    var license = lin.Select(line => Regex.Replace(line, @"license=.*", "license=yes"));
    // No need to write the file here, as it will be overwritten.
    //File.WriteAllLines(installerfilename, license);
    // Select from the edited lines (i.e. "license").
    var lmgr_files = license.Select(line => Regex.Replace(line, @"lmgr_files=.*", "lmgr_files=true"));
    // Now it is time to write!
    File.WriteAllLines(installerfilename, lmgr_files);
