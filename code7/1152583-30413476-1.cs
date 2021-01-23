     public static void WriteExample()
     {
           FileHelperEngine engine = new FileHelperEngine(typeof(SampleType));
    
           // to Read use:
           SampleType[] res = engine.ReadFile("source.txt") as SampleType[];
    
           res[1].Field1 = "test";
           res[1].Field2 = 9;
    
           // to Write use:
           engine.WriteFile("source2.txt", res);
      }
