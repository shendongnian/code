    public void method1(){
      method2().ContinueWith(x => {
        Console.WriteLine("Done");
      });
    }
