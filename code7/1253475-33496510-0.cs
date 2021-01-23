    public class MyClass {
        public void WriteToFile(string text){
            string FileName = "C:\\sample\\sample.txt";
            using(System.IO.StreamWriter WriteToFile = new System.IO.StreamWriter(FileName)){
                WriteToFile.Write(text);
                WriteToFile.Close();
                MessageBox.Show("Succeded, written to file");
            }
        }
    }
