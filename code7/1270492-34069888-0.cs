    public void WriteXml(XmlWriter writer)
            {
                if (this.value == null)
                {
                    writer.WriteValue(this.value?.ToString() ?? string.Empty);
                    return;
                }
                var type = this.value.GetType();
                var memberInfo = type.GetMember(this.value.ToString());
    
                if (memberInfo.Length > 0)
                {
                    var attribute = memberInfo[0].GetCustomAttributes<XmlEnumAttribute>();
    
                    if (attribute != null && attribute.IsNotEmpty())
                    {
                        var xmlEnumAttribute = attribute.FirstOrDefault();
                        if (xmlEnumAttribute != null)
                        {
                            writer.WriteValue(xmlEnumAttribute.Name);
                            return;
                        }
                    }
                }
                writer.WriteValue(this.value.ToString());
            }
