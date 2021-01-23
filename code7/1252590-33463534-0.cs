            for (int k = 0; k < proc.Count; k++){
            for (int i = k + 1; i < proc.Count; i++){
                bool doSwap = false;
                if (proc[k].arrivalTime > proc[i].arrivalTime)
                {
                     doSwap = true;
                }
                else if (proc[k].arrivalTime == proc[i].arrivalTime)
                {
                    if(proc[k].priority > proc[i].priority)
                    {
                          doSwap = true;
                    }
                    else if (proc[k].priority == proc[i].priority )
                    {
                         if(proc[k].brust > proc[i].brust)
                         {
                               doSwap = true;
                         }
                    }
                }
                if(doSwap)
                {
                    temp = proc[i];
                    proc[i] = proc[k];
                    proc[k] = temp;
                }
            }
        }
