    decimal SubordinatesSalary()
    {
      decimal salary = 0;
      Stack<Worker> stack = new Stack<Worker>( Subordinates );
      while ( stack.Count > 0 )
      {
        Worker subordinate = stack.Pop();
        salary = salary + subordinate.SalaryPrim();
        Superior subordinateAsSuperior = subordinate as Superior;
        if ( subordinateAsSuperior != null )
          foreach ( Worker subordinate2 in subordinateAsSuperior.Subordinates )
            stack.Push( subordinate2 );
      }
      return salary;
    }
