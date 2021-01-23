    public void ConsolidateLists()
    {
        while(training.Count > 0 || testing.Count > 0)
        {
            if(training.Count == 0 || training[0] == null)
            {
                Controller.GrabFromList(output, testing);
            }
            else if(testing.Count == 0 || testing[0] == null)
            {
                Controller.GrabFromList(output, training);
            }
            else if(training[0].Index < testing[0].Index)
            {
                Controller.GrabFromList(output, training);
            }
            else
            {
                Controller.GrabFromList(output, testing);
            }
        }
    }
    public static void GrabFromList(List<Person> output, List<Person> target)
    {
        if (target[0] != null)
            output.Add(target[0]);
        target.RemoveAt(0);
    }
