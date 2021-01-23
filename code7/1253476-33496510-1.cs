    public class MyClass {
        public static bool WriteToFile(string text){
            string FileName = "C:\\sample\\sample.txt";
            try {
                using(System.IO.StreamWriter WriteToFile = new System.IO.StreamWriter(FileName)){
                    WriteToFile.Write(text);
                    WriteToFile.Close();
                }
                return true;
            }
            catch {
                return false;
            }
        }
    }
