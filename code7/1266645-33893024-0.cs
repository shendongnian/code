      Byte[] binaryData = new Byte[] {
        0x12, 0x13, 0x14, 0x15
      };
      var result = Enumerable
        .Range(0, binaryData.Length / 2)
        .Select(index => BitConverter.ToInt16(binaryData, index * 2))
        .Select(value => (Int16) unchecked(~value + 1))
        .ToArray();
      // Test
      // "ecee, eaec"
      Console.Write(String.Join(", ", result.Select(item => item.ToString("x4"))));
