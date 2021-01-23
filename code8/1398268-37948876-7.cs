    var templeteList = new List<string> //Consider this as my template
            {
               "ID",
               "Name",
               "Address",
               "Phone",
               "Email",
               "Gender"     
            };
    string csv =students.Elements()
                        .Where(el=>el.Name!="TRXC")
                        .Select(el=>{
                                      string result="";
                                      for(int i=0; i<templeteList.Count;i++)
                                      {
                                        result+=el.Attribute(templateList[i]).Value +",";
                                      }
                                      result+= Environment.NewLine;
                                      return result;
                                    })
                        .Aggregate(new StringBuilder(),
                                   (sb, s) => sb.Append(s),
                                    sb => sb.ToString()
                                   );
