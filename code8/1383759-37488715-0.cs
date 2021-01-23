        private void button1_Click(object sender, EventArgs e)//When button is clicked, button click is true
        {
            int smallMaxSize = 101;
            int[] array = new int[smallMaxSize];
    
            Random numGenerator = new Random();
    
            numGenerator.Next(smallMaxSize);
    
            for (int i=0; i<101; i++)//Generates 100 random numbers from 1-100
            {
                array[i] = numGenerator.Next(smallMaxSize);
                Numbers.Items.Add(array[i]);
            }   
    
            if (buttonClick == true)
            {
                Numbers.Items.Clear();
                int Out;
                int In;
    
                for (Out = smallMaxSize - 1; Out > 1; Out--)
                {
                    for (In = 0; In < Out; In++)
                    {
                        if (array[In] > array[In + 1])
                        {
                            int temp = array[In];
                            array[In] = array[In + 1];
                            array[In + 1] = temp;
                        }
                    }
                }
            }
        }
