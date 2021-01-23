      String[] array = new String[] {
        "TODO 06:15PMJoin Michael",
        "WakeUp",
        "Going to schools"
      };
      var result = array
        .SelectMany(line => {
            int p = line.IndexOf("AM");
            if (p >= 0)
              return new String[] { 
                line.Substring(0, p + "AM".Length), 
                line.Substring(p + "AM".Length) };
            p = line.IndexOf("PM");
            if (p >= 0)
              return new String[] { 
                line.Substring(0, p + "PM".Length), 
                line.Substring(p + "PM".Length) };
            return new String[] { line };
          }
        );
      //.ToArray(); // if you want to have array representation
      // Test
      Console.Write(String.Join(Environment.NewLine, result));
