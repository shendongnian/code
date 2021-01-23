    void Main()
    {
      var animals = new List<Animal>
      {
        new Cat { IsMewling = true },
        new Dog { IsBarking = false },
        new Cat { IsMewling = false },
        new Dog { IsBarking = true }
      };
      var visitor = new LetsHearWhatItHasToSay();
      foreach (var animal in animals)
      {
        animal.Accept(visitor);
      }
    }
