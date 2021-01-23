                List<Type>l=typeof(IUserControlDefaultStyle).Assembly.GetTypes().Where(x => !x.IsSubclassOf(typeof(UserControl)) &&x.GetInterfaces().Contains(typeof(IUserControlDefaultStyle))).ToList();
                if (l.Count > 0)
                {
                    l.ForEach(x=>Console.WriteLine(x.Name+"   is abusing IUserControlDefaultStyle"));
                    throw new Exception("IUserControlDefaultStyle was abused");
                }
