    List<KeyValuePair<string, string>> formDetails = new List<KeyValuePair<string, string>>();
    Type formType = typeof(Form);
    foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
    {
       if (formType.IsAssignableFrom(type))
       {
          using (var frm = (Form)Activator.CreateInstance(formType))
          {
             formDetails.Add(new KeyValuePair<string, string>(frm.Name, frm.Text));
          }
       }
    }
