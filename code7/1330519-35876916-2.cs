    public async Task<int> method2(){
      return Task.FromResult(1);
    }
    
    public void method1(){
      await method2()
      Console.WriteLine("Done");
    }
