    public void writeFile(int[] array){
             using (streamWriter sw = new StreamWriter(filename, true){
                  for(int i = 0; i < array.Length; i++){
                       sw.WriteLine(array[i] + " ");
                  }
             }
        }
