    class ModelClass {
       // for use in algorithm, may be presented in GUI or not
       int Sequence { get; set; }
       string Description { get ; set ;}
       // ... what You want, is is typical model class
       override string ToString() { 
        // return what you want, is presented in GUI
        return Descrition; 
       }
       ModelClass( string n, int i ) ... 
    }
     ...
      
      listBox.Items.Add( new ModelClass(i.ToString(), dr[...] // sequence )
