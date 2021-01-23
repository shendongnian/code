    internal class UnUsedVariableWarningDefinition : ICodeIssue
    {
    	public IEnumerable<IssueReport> Analyze()
    	{
    		var usageMap = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
    		var variableMap = new Dictionary<string, IdentifierNode>(StringComparer.InvariantCultureIgnoreCase);
    
    		foreach (var node in NodeAnalyzerHelper.FindNodesDfs(Root))
    		{
    			var assignmentNode = node as AssignmentNode;
    			if (assignmentNode != null)
    			{
    				var variableNode = assignmentNode.Identifier;
    
    				int usages;
    				if (!usageMap.TryGetValue(variableNode.Identifier, out usages))
    				{
    					usageMap[variableNode.Identifier] = 0;
    					variableMap[variableNode.Identifier] = variableNode;
    				}
    			}
    			else
    			{
    				// not really an assignmentNode,
    				// let's see if we have detected the usage of IdentifierNode somewhere.
    				var variableNode = node as IdentifierNode;
    				if (variableNode != null)
    				{
    					if (usageMap.ContainsKey(variableNode.Identifier))
    						usageMap[variableNode.Identifier]++;
    				}
    			}
    		}
    
    		foreach (var node in usageMap.Where(x => x.Value == 0).Select(x => variableMap[x.Key]))
    		{
    			yield return node.ConstructWarning("No usages of this variable found. Are you sure this is needed?");
    		}
    	}
    }
