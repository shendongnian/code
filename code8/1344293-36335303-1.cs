    var elementsCollection = statusBar.AutomationElement.FindAll(TreeScope.Children, Condition.TrueCondition);
         foreach (AutomationElement element in elementsCollection)
         {
             if (element.Current.AutomationId.Contains("lblFileName"))
             {
                 //do what you need
             }
         }
