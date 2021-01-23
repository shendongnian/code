    public void WriteObject(Stream stream, Object graph)
    {
        IEnumerable<MemberInfo> serializbleMembers =
            targetType.GetMembers(BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic )
                      .Where(p => p.IsDefined(typeof (DataMemberAttribute), false));
        var writer = new StreamWriter(stream);
        writer.WriteLine("<" + targetType.Name + ">");
        foreach (MemberInfo memberInfo in serializbleMembers)
        {
            writer.Write("\t<" + memberInfo.Name + ">");
            var fieldInfo = memberInfo as FieldInfo;
            if(fieldInfo != null)
            {
                writer.Write(fieldInfo .GetValue(graph, null).ToString());
            }
            var propInfo= memberInfo as PropertyInfo;
            if(propInfo != null)
            {
                writer.Write(propInfo.GetValue(graph, null).ToString());
            }
            writer.Write("</" + memberInfo.Name + ">"); 
        }
        writer.WriteLine("</" + targetType.Name + ">");
        writer.Flush();
    }
