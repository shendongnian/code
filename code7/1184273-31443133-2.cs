    StackTrace st = new StackTrace();
      // Display the most recent function call.
      StackFrame sf = st.GetFrame(0);
      Console.WriteLine();
      Console.WriteLine("  Exception in method: ");
      Console.WriteLine("      {0}", sf.GetMethod());
      if (st.FrameCount >1)
      {
         // Display the highest-level function call  
         // in the trace.
         sf = st.GetFrame(st.FrameCount-1);
         Console.WriteLine("  Original function call at top of call stack):");
         Console.WriteLine("      {0}", sf.GetMethod());
      }
