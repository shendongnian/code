    public override ProblemCollection Check(Member member)
    {
       Method method = member as Method;
       bool isCatchExists = false;
       bool isLogError = false;
            
       if(method != null)
       {
          //Get all the instrections of the method.
          InstructionCollection iList = method.Instructions;
          foreach (Instruction item in iList)
          {
             #region Check For Catch
             if (item.OpCode == OpCode._Catch)
             {
                isCatchExists = true;
             }
             #endregion
             #region Check for Error Logging (log4net)
             if (item.Value != null)
             {
                 if (item.OpCode == OpCode.Callvirt && item.Value.ToString() == "log4net.ILog.Error")
                 {
                   isLogError = true;
                 }
             }
             #endregion
                    
          }
          if (isCatchExists && !isLogError)
          {
            Problems.Add(new Problem(this.GetNamedResolution("AddLogging", member.FullName)));
          }
        }
            return this.Problems;
     }
