public void MyUpdate(MyType foo)
{
    bool stop = false;
    
    /*Prep code for the loops*/        
    for (var i = 0; !stop && (i < something.Count); i++)
    {
        for (var j = 0; !stop && (j < something[i].Stuff.Count); j++)
        {
            Data dataRX = something[i].Stuff[j].First;
            if (dataRX != null && dataRX.ID.Equals(globalNonsense.ID))
            {
                // Update Data with the latest changes
                dataRX.fooBuddy = foo;
                stop = true;
            }
        }
    }
}
