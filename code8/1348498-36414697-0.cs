    private void computeVelocity()
        {
            //calc velocity of each particle for printing
            double binSize = 0.5;
            double velocityOfParticle = 0.0;
            double averageSquareVelocity = 0.0;
            int maxArrayValue = 0;
            int binArraySize = 0;
            int z;
            double[] velocityArray = new double[Particle.allParticles.Count];
    
            for (int counter = 0; counter < Particle.allParticles.Count; counter++)
            {
                averageSquareVelocity = Particle.allParticles[counter].SquareVelocity;
                velocityOfParticle = Math.Sqrt(averageSquareVelocity);
                velocityArray[counter] = velocityOfParticle; 
            }
            maxArrayValue = Convert.ToInt32(Math.Round(velocityArray.Max()));
            binArraySize = Convert.ToInt32(Math.Round(maxArrayValue / binSize));
            //numberOfBins = Math.Round(maxArrayValue / binSize);
            int [] binCountArray = new int[numberOfParticles];
            int incrementTerm = 0;
            Array.Clear(binCountArray, 0, binCountArray.Length);
            for(double counter = 0.0; counter <= maxArrayValue; counter = counter + binSize)
            {
                if(counter > binSize)
                {
                    incrementTerm = incrementTerm + 1;
                }
                z = 0;
                for(int i = 0; i < numberOfParticles; i++)
                {
                    if((velocityArray[i] <= counter) && (velocityArray[i] > counter - binSize))
                    {
                        z++;
                    }                  
                }     
                binCountArray[incrementTerm] = z;
            }
            foreach (var item in binCountArray)
            {
                VelocityValues.WriteLine(item);
            }
          }
