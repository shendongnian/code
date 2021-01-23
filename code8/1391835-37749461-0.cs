    if (dynamicType.IsGenericType)
                {
                    var genericDynamicType = dynamicType.GetGenericTypeDefinition();
                    Func<Panel> generatePanelMethod = null;
                    if (genericDynamicType.In(typeof (List<>), typeof (IEnumerable<>), typeof (IList<>)))
                        generatePanelMethod = () => this.GenerateListPanel(workflowConfiguration);
                    else if (genericDynamicType == typeof(Dictionary<,>))
                        generatePanelMethod = () => this.GenerateDictionaryPanel(workflowConfiguration);
                    if (generatePanelMethod == null) continue;
                    panelList.Add(generatePanelMethod());
                }
