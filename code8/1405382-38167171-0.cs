    // Array of random integers
    private const int MAX = 29;
    private readonly int[] myArray = new int[MAX];
    
    private void btnOne_Click(object sender, EventArgs e)
    {
      FillArray();
      Task.Factory.StartNew(() =>
      {
        for (var outer = 0; outer < MAX; outer++)
        {
          for (var inner = 0; inner < MAX - 1; inner++)
          {
            if (myArray[inner] > myArray[inner + 1])
            {
              Swap(ref myArray[inner + 1], ref myArray[inner]);
            }
            ShowArray();
            Thread.Sleep(50);
          }
        }
      });
    }
    
    private void FillArray()
    {
      var random = new Random();
      for (var i = 0; i < MAX; i++)
      {
        myArray[i] = random.Next(1, 100);
      }
    }
    
    private void ShowArray()
    {
      Invoke(new MethodInvoker(delegate
      {
        listBox1.Items.Clear();
        for (var i = 0; i < MAX; i++)
        {
          listBox1.Items.Add(myArray[i]);
        }
      }));
    }
    
    private static void Swap(ref int var1, ref int var2)
    {
      var temp_value = var1;
      var1 = var2;
      var2 = temp_value;
    }
