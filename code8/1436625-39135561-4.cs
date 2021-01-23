    public Creature()
    {
        geneLength = 36;
        this.Chromosome = new byte[geneLength];
        fitness = 0;
    }
    
    for (int i = 0; i < this.Chromosome.Length; i++)
    {
        byte g = this.Chromosome[i]; // this line is useless
        this.Chromosome[i] = (byte)rn.Next(0, 2);
        geneString += this.Chromosome[i].ToString();
    }
