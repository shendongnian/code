    ProcessPriorityClass GetPriority(Process p)
    {
        try{
            return p.PriorityClass;
        }catch{
            return (ProcessPriorityClass)0;
        }
    }
