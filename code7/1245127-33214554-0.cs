      var numbers = File
        .ReadLines(@"C:\MyText.txt")
        .Select(line => line.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length);
     // Test: 4, 3, 6, 4
     Console.Write(String.Join(", ", numbers));
