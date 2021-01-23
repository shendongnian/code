    public static class Materials
    {
       public static uint Wood = 2,
       public static uint Metal = 3,
       public static uint Dirt = 5,
       // etc...
    }
    if(matA*matB == Materials.Wood*Materials.Metal)
    {
       //play sound for metal-wood collision
    }
    //or with enums but annoying casts are necessary...
    enum Materials:uint
    {
       Wood = 2,
       Metal = 3,
       Dirt = 5,
       // etc...
    }
    if((uint)matA*(uint)matB == (uint)Materials.Wood*(uint)Materials.Metal)
    {
       //play sound for metal-wood collision
    }
