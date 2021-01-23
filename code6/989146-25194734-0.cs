                int positionX = 0;
                int positionY = 0;
    
                int direction = 0; // The initial direction is "right"
                int stepsCount = n - 1; // stepsCount decrements after 1/2/2/2/2... turns
                int stepPosition = 1; // 1 steps already performed
                int counter = 0; // counter increments after every change in direction
                
                for (int i = 1; i < n * n + 1; i++)
                {
                    matrix[positionY, positionX] = i;
    
                    //moving logic:
    
                    if (stepPosition <= stepsCount)
                    {
                        stepPosition++;
                    }
                    else
                    {
                        counter++;
                        stepPosition = 1;
    
                        if (counter % 2 != 0)
                        {
                            stepsCount = stepsCount - 1;
                            direction = (direction + 1) % 4;
                        }
                        else if (counter % 2 == 0)
                        {
                            direction = (direction + 1) % 4;
                        }
    
                    }
