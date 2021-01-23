    This will write it to the file location of your choice. 
     public void writeToFile(){
     
     System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", getArea().toString());
     }
