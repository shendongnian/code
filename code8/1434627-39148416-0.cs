    foreach(CodeElement codeElement in codeElements)
    {
        switch(codeElement.Kind)
        {
            case vsCMElement.vsCMElementNamespace:
                CodeNamespace codeNamespace = codeElement as CodeNamespace;
                CodeElements childCodeElements = codeNamespace.Members;
                ProcessCodeElements(childCodeElements);
                break;
            case vsCMElement.vsCMElementEnum:
                CodeEnum codeEnum = codeElement as CodeEnum;
                Write(codeEnum.Name);
			
                // get the source code of the enum
				string sourceCodeEnum = 
                    codeEnum.StartPoint.CreateEditPoint().GetText(codeEnum.EndPoint);
                // a regular expression capturing the base type
				System.Text.RegularExpressions.Regex regex 
                    = new System.Text.RegularExpressions.Regex(
                        @"\benum .*\s*\:\s*(?<underlyingType>.*)");
				var match = regex.Match(sourceCodeEnum);
				if (match.Success)
				{
					WriteLine(" : " + match.Groups["underlyingType"].Value);
				}
                
                break;
        }
    }
