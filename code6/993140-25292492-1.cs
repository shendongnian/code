    bool AreDatesSequential = true;
    for (int i = 1; i < AxiomSubSet.Count; i++)
    {
         if (AxiomSubSet[i].Term < AxiomSubSet[i - 1].Term)
         {
             AreDatesSequential = false;
             break;
         }
    }
