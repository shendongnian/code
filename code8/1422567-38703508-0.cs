    struct Vector3
    {
       public float x;
       public float y;
       public float z;
    
       public Vector3(float[] vals)
       {
          if(vals.Length != 3)
             throw new ArgumentException();
          x = vals[0]; y = vals[1]; z = vals[2];
       }
    }
