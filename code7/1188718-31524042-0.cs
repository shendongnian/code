     public Manejo_Ficheros(String filepath){
      this.path = filepath;
        if(!File.Exists(path+".dat")){
            using (fs = new FileStream(path + ".dat", FileMode.Create));
            {
              this.N = 0;
              bw = new BinaryWriter(fs);
              fs.Seek(0,SeekOrigin.Begin);
              bw.Write(N);
            }
        }else{
            using (fs = new FileStream(path + ".dat", FileMode.Open))
            {
              br = new BinaryReader(fs);
              fs.Seek(0,SeekOrigin.Begin);
              this.N = br.ReadInt32();
            }    
        }
