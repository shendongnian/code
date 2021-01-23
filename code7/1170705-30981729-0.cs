    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
    {
        if (xmlInputNode.Attributes[sm_Attribute] != null) 
        {
            xmlInputNode.Attributes[sm_Attribute].InnerText = sm_AttributeValue.ToString();
        }
    }));
