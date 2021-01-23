      var aryProp = new Dictionary<string, string>();
      aryProp.Add("Name", button.Name);
      aryProp.Add("Width", button.Width.ToString());
      foreach (var element in aryProp)
      {
        Console.WriteLine(element.Key + " " + element.Value);
      }
