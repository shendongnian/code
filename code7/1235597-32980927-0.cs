            //Setup the FontResolver in Global.asax.cs
            PdfSharp.Fonts.GlobalFontSettings.FontResolver = new MyFontResolver();
            //define the font as usual when generating the PDF, for example:
            Style style = document.Styles["Normal"];
            style.Font.Name = "Arial Unicode MS";
            style.Font.Size = 8;
           //Create a new class called MyFontResolver:
           using PdfSharp.Fonts;
           using System;
           using System.Collections.Generic;
           using System.IO;
           using System.Linq;
           using System.Reflection;
           using System.Text;
        /// <summary>
        /// Font resolver that extends the default implementation to handle any additional font families we include in embedded resources
        /// The font should be added to the font directory with build action = 'Embedded Resource'
        /// </summary>
    public class MyFontResolver : IFontResolver
    {
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Ignore case of font names.
            var name = familyName.ToLower();
            // Add fonts here
            switch (name)
            {
                case "arial unicode ms":
                    return new FontResolverInfo("ArialUnicodeMS#");
            }
            //Return a default font if the font couldn't be found
            //this is not a unicode font 
            return PlatformFontResolver.ResolveTypeface("Arial", isBold, isItalic);
        }
        /// <summary>
        /// Return the font data for the fonts.
        /// </summary>
        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "ArialUnicodeMS#":
                    return FontHelper.ArialUnicodeMS;
            }
            return null;
        }
    }
    /// <summary>
    /// Helper class that reads font data from embedded resources.
    /// </summary>
    public static class FontHelper
    {
        public static byte[] ArialUnicodeMS
        {
            //the font is in the folder "/fonts" in the project
            get { return LoadFontData("MyApp.fonts.ARIALUNI.TTF"); }
        }
        /// <summary>
        /// Returns the specified font from an embedded resource.
        /// </summary>
        static byte[] LoadFontData(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + name);
                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }
    }
