    // Enumerate the resources in the file.
          ResXResourceReader rr = new ResXResourceReader(resxFilename);
          rr.UseResXDataNodes = true;
          IDictionaryEnumerator dict = rr.GetEnumerator();
          while (dict.MoveNext()) {
             ResXDataNode node = (ResXDataNode) dict.Value;
             Console.WriteLine("{0,-20} {1,-20} {2}", 
                               node.Name + ":", 
                               node.GetValue((ITypeResolutionService) null), 
                               ! String.IsNullOrEmpty(node.Comment) ? "// " + node.Comment : "");
          }
