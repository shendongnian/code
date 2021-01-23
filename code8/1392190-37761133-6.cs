      var file = ShellFile.FromFilePath("your image.jpg");
      using (var writer = file.Properties.GetPropertyWriter())
      {
          writer.WriteProperty(file.Properties.System.Comment, "hello");
      }
