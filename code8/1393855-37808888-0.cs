      public void TryToCatchMethod() {
        try {
          MyAsyncMethod();
        } catch (Exception exception) {
          //tha catch is never called
          Debug.WriteLine(exception.ToString());
        }
      }
      public async void MyAsyncMethod() {
        throw new Exception();
      }
