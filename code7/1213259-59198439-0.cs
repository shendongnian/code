            var stackTraces = new StackTrace();
            foreach (var stackFrame in stackTraces.GetFrames())
            {
                MethodBase methodBase = stackFrame.GetMethod();
                TestPropertyAttribute[] attributes = methodBase.GetCustomAttributes(typeof(TestPropertyAttribute), false) as TestPropertyAttribute[];
                if (attributes != null && attributes.Length >= 1)
                {
                    variantName = attributes.FirstOrDefault(x => x.Name.Equals("VariantName"))?.Value;
                }
            }
