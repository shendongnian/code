    Form GetFormByName(string name)
        {
            System.Reflection.Assembly myAssembly =System.Reflection.Assembly.GetExecutingAssembly();
            foreach(Type type in myAssembly.GetTypes())
            {
                if (type.BaseType!=null&& type.BaseType.FullName == "System.Windows.Forms.Form")
                {
                    if (type.FullName == name)
                    {
                        var form = Activator.CreateInstance(Type.GetType(name)) as Form;
                        return form;
                    }
                }
            }
                return null;
        }
