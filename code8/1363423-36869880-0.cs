        //see: http://www.codeproject.com/Articles/444371/Creating-WPF-Data-Templates-in-Code-The-Right-Way
        private static DataTemplate CreateTemplate(UniprogCellVM cell)
        {
            var tcell = cell.GetType();
            var sb = new StringBuilder();
            sb.AppendFormat("<DataTemplate DataType=\"{{x:Type local:{0}}}\">", tcell.Name);
            sb.Append("<local:UniprogCellControl ");
            sb.Append("Content=\"{Binding Path=.}\" ");
            sb.Append("Header=\"{Binding Path=.}\" ");
            sb.AppendFormat("Style=\"{{DynamicResource Root{0}BoxStyleKey}}\" ", cell.Interaction);
            sb.Append(">");
            sb.Append("</local:UniprogCellControl>");
            sb.Append("</DataTemplate>");
            var context = new ParserContext();
            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("local", tcell.Namespace, tcell.Assembly.FullName);
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("local", "local");
            var template = (DataTemplate)XamlReader.Parse(sb.ToString(), context);
            return template;
        }
