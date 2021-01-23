          List<string> sbColors = new List<string>();
          Type colorType = typeof(System.Drawing.Color);
          PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
          foreach (PropertyInfo c in propInfoList)
          {
             sbColors.Add(c.Name);
          }
