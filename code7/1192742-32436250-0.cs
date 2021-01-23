    //this code comes from my code block in the question.
    ...
    foreach (MPXJ.Task task in mpx.AllTasks.ToIEnumerable())
    {
        //if the string values retrieved from these has a valid value that's returned, that value is the Outline Code assigned to the task 
        string Outline_code_1  = task.GetOutlineCode(1);
        string Outline_code_2  = task.GetOutlineCode(2);
        string Outline_code_3  = task.GetOutlineCode(3);
        string Outline_code_4  = task.GetOutlineCode(4);
        string Outline_code_5  = task.GetOutlineCode(5);
        string Outline_code_6  = task.GetOutlineCode(6);
        string Outline_code_7  = task.GetOutlineCode(7);
        string Outline_code_8  = task.GetOutlineCode(8);
        string Outline_code_9  = task.GetOutlineCode(9);
        string Outline_code_10 = task.GetOutlineCode(10);
    }
    ...
