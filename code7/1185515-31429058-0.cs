    public class DNA {
        float size;
        float speed;
        float drag;
        float eyeSize;
        int numberOfEyes;
        float color_r;
        [...]
    
       public static DNA operator +(DNA dna1, dna1 rhs) 
       {
           DNA newDNA = new DNA ();
           newDNA.size = (dna1.size+dna2.size);
           newDNA.speed = (dna1.speed+dna2.speed);
           [...]
    
           return newDNA;
       }
    }
