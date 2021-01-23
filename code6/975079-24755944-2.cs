    public class ColorData
    {
       public int Id { get; set; }
    
       public int Argb { get; set; }
    
       public System.Drawing.Color Color
       {
          get { return new System.Drawing.Color.FromArgb(this.Argb); }
          set 
          { 
             if(value!=null)
                 this.Argb = value.ToArgb(); 
             else
                 this.Argb = 0;
          }
       }
    }
