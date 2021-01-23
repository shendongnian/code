    public struct Gene
    {
        int[] alleles;
        int fitness;
        float likelihood;
        // Test for equality.
        public static bool operator ==(Gene gn1, Gene gn2) 
        {
            for (int i=0;i<4;i++)
            {
                if (gn1.alleles[i] != gn2.alleles[i]) return false;
            }
            return true;
        }
        public static bool operator !=(Gene gn1, Gene gn2)
        {
            return !(gn1 == gn2);
        }
    }
