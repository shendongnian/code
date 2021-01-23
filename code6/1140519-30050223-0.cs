                var sb = new StringBuilder("<root>");
                foreach (var node in xmlNodes)
                {
                    sb.AppendLine(node.OuterXml);
                }
                sb.AppendLine("</root>");
                var ds = new DataSet();
                ds.ReadXml(new StringReader(sb.ToString()));
    
    
                return ds.Tables[0];
