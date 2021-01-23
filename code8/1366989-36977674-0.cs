    public class Utility
    {
        public static string TakeScreenshot()
        {
            String now = DateTime.Now.ToString("MM-dd-yyy hh-mm tt ");
            string FileName = now + "Screenshot.png";
            try
            {
                Screenshot ss = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
                ss.SaveAsFile(@".\Screenshots\" + FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return FileName;
        }
    }
