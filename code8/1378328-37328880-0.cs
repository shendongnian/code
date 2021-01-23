        try
        {
            if (File.Exists(...))
            {
                // Download file
            }
            else
            {
                return View("FileNotFound");
            }
        }
        catch (Exception ex)
        {
            return View("FileError", ex);
        }
