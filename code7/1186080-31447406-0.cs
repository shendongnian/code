    public static class TestEliminateSwitch
    {
        public static string GetImagePath()
        {
            var formatFactory = new FormatFactory();
            var instance = formatFactory.GetFomatClass("PDF");
            return instance.GetImagePath("TRUE");
        }
    }
    public class FormatFactory
    {
        public FormatBase GetFomatClass(string formatName)
        {
            string className = typeof (FormatBase).FullName.Replace("Base", formatName);
            return Assembly.GetExecutingAssembly()
                .CreateInstance(className) as FormatBase;
        }
    }
    public abstract class FormatBase
    {
        public string fileNameUpper = string.Empty;
        public string fileNamelabel = string.Empty;
        public virtual string GetImagePath(string IsEmployee)
        {
            return string.Format("{0}{1}", IsEmployee.ToUpper() == "TRUE" ? fileNameUpper : fileNamelabel, GetFileExtention());
        }
        public abstract string GetFileExtention();
    }
    class FormatPDF : FormatBase
    {
        public override string GetFileExtention()
        {
            return ".PDF";
        }
    }
    class FormatGIF : FormatBase
    {
        public override string GetFileExtention()
        {
            return ".GIF";
        }
    }
