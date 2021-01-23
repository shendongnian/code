                var appProperty = vbe.VBProjects
                    .Cast<VBProject>()
                    .Where(project => project.Protection == vbext_ProjectProtection.vbext_pp_none)
                    .SelectMany(project => project.VBComponents.Cast<VBComponent>())
                    .Where(component => component.Type == vbext_ComponentType.vbext_ct_Document
                    && component.Properties.Count > 1)
                    .SelectMany(component => component.Properties.OfType<Property>())
                    .FirstOrDefault(property => property.Name == "Application");
                if (appProperty != null)
                {
                    Application = (TApplication)appProperty.Object;
                }
                else
                {
                    Application = (TApplication)Marshal.GetActiveObject(applicationName + ".Application");
                }
