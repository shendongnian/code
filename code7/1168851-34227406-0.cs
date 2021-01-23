     var helpAttr = memberExpr.Member.GetCustomAttributes(false).OfType<HelpTextAttribute>().SingleOrDefault();
                Assembly resourceAssembly = helpAttr.ResourceType.Assembly;
                string[] manifests = resourceAssembly.GetManifestResourceNames();
                // remove .resources
                for (int i = 0; i < manifests.Length; i++)
                {
                    manifests[i] = manifests[i].Replace(".resources", string.Empty);
                }
                string manifest = manifests.Where(m => m.EndsWith(helpAttr.ResourceType.FullName)).First();
                ResourceManager manager = new ResourceManager(manifest, resourceAssembly);
                
                if (helpAttr != null)
                    return new MvcHtmlString(@"<span class=""help"">" + manager.GetString(helpAttr.ResourceName) + "</span>");
