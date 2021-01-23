    public class WhatEverClassHasTheExecuteCommandMethod
    {
         private static object _lock = new object();
         public void ExecuteCommand(IAsciiCommand command, IAsciiCommandSynchronousResponder responder)
         {
              lock (_lock)
                  if (commander.IsConnected)                  
                     commander.ExecuteCommand(command, responder);
         }
    }
