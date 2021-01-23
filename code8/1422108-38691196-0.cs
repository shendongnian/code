    private void button_Click(object sender, EventArgs e)
        {
            var scheduleDate = new DateTime(2010, 03, 11);
            var typelist = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                      .Where(t => t.Namespace == "AssetConsultants")
                      .ToList();
            foreach (Type t in typelist)
            {
                var methodInfo = t.GetMethod("Start", new Type[] { typeof(DateTime) });
                if (methodInfo == null) // the method doesn't exist
                {
                    // throw some exception
                }
                var o = Activator.CreateInstance(t);
                methodInfo.Invoke(o, new object[] { scheduleDate });
            }
        }
