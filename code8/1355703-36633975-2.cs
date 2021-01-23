        if (!type.contains("RTRIM"))
            {
                type = type.Replace("TRIM", "RTRIM"); 
                if (!type.contains("RRTRIM"))
                {
                    type = type.Replace("RRTRIM", "RTRIM");
                }
                StringBuilder builder =newStringBuilder();
                builder.AppendLine(" .....bla bla..."); 
                if (type.Trim() != ""){
                builder.AppendLine(@"   WHERE ({0}) ");
                }
            }
