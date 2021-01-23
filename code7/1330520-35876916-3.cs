      public Task<int> method2(){
          return Task.FromResult(1);
        }
        
        public void method1(){
          method2().ContinueWith(x => {
            Console.WriteLine("Done");
          });
        }
