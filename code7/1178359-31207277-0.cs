    void Prompt()
    {
      // ...
      var obj = new Input();
      // ...
      if (someCondition)
      {
        Prompt(); // recursive
      }
      // ...
      // Is 'obj' used here?
    }
