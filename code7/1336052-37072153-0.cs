        public controlTypeEntered wpf_Control<controlTypeEntered>(List<wpfControls_PropertyTypes> propertyType, List<String> propertyValue, WpfControl controlWindow) where controlTypeEntered : WpfControl
        {
            controlTypeEntered wpfElement = (controlTypeEntered)Activator.CreateInstance(typeof(controlTypeEntered), new object[] { controlWindow });
            Hashtable ht = new Hashtable();
            for (var i = 0; i < propertyType.Count; i++)
            {
                ht.Add(propertyType[i], propertyValue[i]);
            }
            for (var i = 0; i < propertyType.Count; i++)
            {
                // Identifying the control on basis of its search properties.
                if (propertyType[i] == wpfControls_PropertyTypes.ClassName)
                {
                    wpfElement.SearchProperties[WpfControl.PropertyNames.ClassName] = propertyValue[i];
                }
                else if (propertyType[i] == wpfControls_PropertyTypes.ControlType)
                {
                    wpfElement.SearchProperties[WpfControl.PropertyNames.ControlType] = propertyValue[i];
                }
                else if (propertyType[i] == wpfControls_PropertyTypes.FriendlyName)
                {
                    wpfElement.SearchProperties[WpfControl.PropertyNames.FriendlyName] = propertyValue[i];
                }
                else if (propertyType[i] == wpfControls_PropertyTypes.Name)
                {
                    wpfElement.SearchProperties[WpfControl.PropertyNames.Name] = propertyValue[i];
                }
                else if (propertyType[i] == wpfControls_PropertyTypes.TechnologyName)
                {
                    wpfElement.SearchProperties[WpfControl.PropertyNames.TechnologyName] = propertyValue[i];
                }
            }
            return (controlTypeEntered)Convert.ChangeType(wpfElement, typeof(controlTypeEntered));
        }
