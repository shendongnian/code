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
