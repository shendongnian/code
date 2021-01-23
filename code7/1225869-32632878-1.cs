    /// <summary>
    /// Convertetion PDF to image.
    /// </summary>
    /// <param name="Path">Path to file for convertetion</param>
    /// <param name="PDFfile">Book name on HDD</param>
    /// <param name="Devise">Select one of the formats, jpg</param>
    /// <param name="PageFormat">Select one of page formats, like A4</param>
    /// <param name="qualityX"> Select quality, 200X200 ~ 1200X1900</param>
    /// <param name="qualityY">Select quality, 200X200 ~ 1200X1900</param>
        public void CreatPDF(string Path, string PDFfile, GhostscriptSharp.Settings.GhostscriptDevices Devise,
    GhostscriptSharp.Settings.GhostscriptPageSizes PageFormat, int qualityX, int qualityY)
        {
            GhostscriptSharp.GhostscriptSettings SettingsForConvert = new GhostscriptSharp.GhostscriptSettings();
            SettingsForConvert.Device = Devise;
            GhostscriptSharp.Settings.GhostscriptPageSize pageSize = new GhostscriptSharp.Settings.GhostscriptPageSize();
            pageSize.Native = PageFormat;
            SettingsForConvert.Size = pageSize;
            SettingsForConvert.Resolution = new System.Drawing.Size(qualityX, qualityY);
            GhostscriptSharp.GhostscriptWrapper.GenerateOutput(Path, @"C:\" + PDFfile + "\\" + PDFfile + "_" + "%d.jpg", SettingsForConvert); // here you could set path and name for out put file.
        }
