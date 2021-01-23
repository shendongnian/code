            var resNames = ieDriver.ExecuteScript("var keys = [];for(var key in window.performance.getEntriesByType(\"resource\")){keys.push(key);} return keys;");
            Dictionary<string, Dictionary<string, object>> resTimings = new Dictionary<string, Dictionary<string, object>>();
            foreach (string name in (System.Collections.ObjectModel.ReadOnlyCollection<object>)resNames)
            {
                var resource = new Dictionary<string, object>();
                var resProperties = ieDriver.ExecuteScript(string.Format("var keys = [];for(var key in window.performance.getEntriesByType(\"resource\")[{0}]){{keys.push(key);}} return keys;", name));
                foreach (string property in (System.Collections.ObjectModel.ReadOnlyCollection<object>)resProperties)
                {
                    resource.Add(property, ieDriver.ExecuteScript(string.Format("return window.performance.getEntriesByType(\"resource\")[{0}].{1};", name, property)));
                }
                resTimings.Add(name, resource);
            }
