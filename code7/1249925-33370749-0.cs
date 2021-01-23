    for (int i = 0; i < newArray.Length; i++)
    { // <-- Add this
      bool loop = true;
      do
      {
        try
        {
          newArray[i] = Convert.ToInt32(Console.ReadLine());
          loop = false;
        }
        catch
        {
          Console.WriteLine("You may only enter numbers!");  
        }
      } while (loop);
      
      Console.Write("You entered the following numbers: ");
    }
