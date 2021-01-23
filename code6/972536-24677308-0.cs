        private void PopulateProperties(RuntimeType.RuntimeTypeCache.Filter filter, RuntimeType declaringType, Dictionary<string, List<RuntimePropertyInfo>> csPropertyInfos, bool[] usedSlots, ref RuntimeType.ListBuilder<RuntimePropertyInfo> list)
        {
          int token = RuntimeTypeHandle.GetToken(declaringType);
          if (MetadataToken.IsNullToken(token))
            return;
          MetadataEnumResult result;
          RuntimeTypeHandle.GetMetadataImport(declaringType).EnumProperties(token, out result);
          RuntimeModule module = RuntimeTypeHandle.GetModule(declaringType);
          int numVirtuals = RuntimeTypeHandle.GetNumVirtuals(declaringType);
          for (int index1 = 0; index1 < result.Length; ++index1)
          {
            int num = result[index1];
            if (filter.RequiresStringComparison())
            {
              if (ModuleHandle.ContainsPropertyMatchingHash(module, num, filter.GetHashToMatch()))
              {
                Utf8String name = declaringType.GetRuntimeModule().MetadataImport.GetName(num);
                if (!filter.Match(name))
                  continue;
              }
              else
                continue;
            }
            bool isPrivate;
            RuntimePropertyInfo runtimePropertyInfo = new RuntimePropertyInfo(num, declaringType, this.m_runtimeTypeCache, out isPrivate);
            if (usedSlots != null)
            {
              if (!(declaringType != this.ReflectedType) || !isPrivate)
              {
                MethodInfo methodInfo = runtimePropertyInfo.GetGetMethod();
                if (methodInfo == (MethodInfo) null)
                  methodInfo = runtimePropertyInfo.GetSetMethod();
                if (methodInfo != (MethodInfo) null)
                {
                  int slot = RuntimeMethodHandle.GetSlot((IRuntimeMethodInfo) methodInfo);
                  if (slot < numVirtuals)
                  {
                    if (!usedSlots[slot])
                      usedSlots[slot] = true;
                    else
                      continue;
                  }
                }
                if (csPropertyInfos != null)
                {
                  string name = runtimePropertyInfo.Name;
                  List<RuntimePropertyInfo> list1 = csPropertyInfos.GetValueOrDefault(name);
                  if (list1 == null)
                  {
                    list1 = new List<RuntimePropertyInfo>(1);
                    csPropertyInfos[name] = list1;
                  }
                  for (int index2 = 0; index2 < list1.Count; ++index2)
                  {
                    if (runtimePropertyInfo.EqualsSig(list1[index2]))
                    {
                      list1 = (List<RuntimePropertyInfo>) null;
                      break;
                    }
                  }
                  if (list1 != null)
                    list1.Add(runtimePropertyInfo);
                  else
                    continue;
                }
                else
                {
                  bool flag = false;
                  for (int index2 = 0; index2 < list.Count; ++index2)
                  {
                    if (runtimePropertyInfo.EqualsSig(list[index2]))
                    {
                      flag = true;
                      break;
                    }
                  }
                  if (flag)
                    continue;
                }
              }
              else
                continue;
            }
            list.Add(runtimePropertyInfo);
          }
        }
