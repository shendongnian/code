            resultEnumsForTasks = new Dictionary<string, Dictionary<UInt16, string>>();
            foreach (var task in myTasks)
            {
                Dictionary<UInt16, string> _enum =  new Dictionary<UInt16,string>();
                TaskAbstract instance = (TaskAbstract)task.CreateExport().Value;
                MemberInfo resultEnum = instance.GetType().GetMember("ResultEnum").FirstOrDefault();
                if (resultEnum == null)
                    continue;
                string[] names = Enum.GetNames(resultEnum as Type);
                IList<int> vals = (IList<int>)Enum.GetValues(resultEnum as Type);
                for (int i = 0; i < names.Length; i++)
                {
                    _enum.Add(Convert.ToUInt16(vals[i]), names[i]);
                }
                resultEnumsForTasks.Add(instance.GetType().Name, _enum);
            }
